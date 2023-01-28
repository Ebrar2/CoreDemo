using CoreDemo.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using System.Globalization;
using System.Threading;

namespace CoreDemo.Controllers
{
    [AllowAnonymous]
    public class UserController : Controller
    {
        private readonly IStringLocalizer<UserController> localizer;

        public UserController(IStringLocalizer<UserController> localizer)
        {
           

            this.localizer = localizer;
        }
        public IActionResult Index()
        { 
            
            var nameSurname = localizer["NameSurname"];

            //var cultureInfo = CultureInfo.GetCultureInfo("en-US");
            //Thread.CurrentThread.CurrentCulture = cultureInfo;
            //Thread.CurrentThread.CurrentUICulture = cultureInfo;
            //var say_hello_value2 = localizer["Say_Hello"];
            return View();
        }
        [HttpGet]
        public IActionResult Create()
        {


            //var cultureInfo = CultureInfo.GetCultureInfo("en-US");
            //Thread.CurrentThread.CurrentCulture = cultureInfo;
            //Thread.CurrentThread.CurrentUICulture = cultureInfo;
            //var say_hello_value2 = localizer["Say_Hello"];
            return View();
        }
        [HttpPost]
        public IActionResult Create(UserCreateRequestModel createRequestModel)
        {


            return View(createRequestModel);
        }
    }
}
