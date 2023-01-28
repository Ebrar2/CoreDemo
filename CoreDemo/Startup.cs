using CoreDemo.LocalizationLanguage;
using CoreDemo.Resources;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Localization.Routing;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace CoreDemo
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllersWithViews();
            services.AddMvc(configure =>
            {
                var policy = new AuthorizationPolicyBuilder().RequireAuthenticatedUser().Build();
                configure.Filters.Add(new AuthorizeFilter(policy));
            });
            services.AddLocalization(opt => { opt.ResourcesPath = "Resources"; });
            
            services.AddMvc()
                .AddViewLocalization()
                .AddDataAnnotationsLocalization(options=>
                options.DataAnnotationLocalizerProvider=(type,factory)=>
                {
                    var assemblyName = new AssemblyName(typeof(SharedModelResource).GetTypeInfo().Assembly.FullName);
                    return factory.Create(nameof(SharedModelResource), assemblyName.Name);
                }
                )
                ;
            services.Configure<RequestLocalizationOptions>(opt =>
            {
                var supportedCultures = new List<CultureInfo>
                {
                  new CultureInfo("en-US"),
                  new CultureInfo("tr-TR")


                };
                opt.DefaultRequestCulture = new RequestCulture("tr-TR");
                opt.SupportedCultures = supportedCultures;
                opt.SupportedUICultures = supportedCultures;
                //opt.RequestCultureProviders = new List<IRequestCultureProvider>
                //{
                //    new QueryStringRequestCultureProvider(),
                //    new CookieRequestCultureProvider(),
                //    new AcceptLanguageHeaderRequestCultureProvider(),
                //            };
                opt.RequestCultureProviders = new[]
                {
                 new    RouteDataRequestCultureProvider()
                {
                    Options=opt
            }
                } ;

    });
            services.AddSession();
            services.AddAuthentication(
            
                CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(x=>
                {
                    x.LoginPath = "/Login/Index";
                }

                );
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();


            app.UseAuthentication();
            app.UseSession();
            app.UseStatusCodePagesWithReExecute("/ErrorPage/Index","?code={0}");

           
            app.UseRouting();

            app.UseAuthorization();
            
            var options= app.ApplicationServices.GetService<IOptions<RequestLocalizationOptions>>();
            app.UseRequestLocalization(options.Value); 

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
