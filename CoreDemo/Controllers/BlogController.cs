using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAcessLayer.Concrete;
using DataAcessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Localization;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;

namespace CoreDemo.Controllers
{
    public class BlogController : Controller
    {
       
        BlogManager blogManager = new BlogManager(new EfBlogRepository());
        CategoryManager categoryManager = new CategoryManager(new EfCategoryRepository());
     //   WriterManager writerManager = new WriterManager(new EfWriterRepository());
        UserManager userManager = new UserManager(new EfUserRepository());  

        private IStringLocalizer<SharedResource> _localizer;
        public BlogController(IStringLocalizer<SharedResource> localizer)
        {
            _localizer = localizer;
        }
        [AllowAnonymous]
        public IActionResult Index()
        {
            
            var values = blogManager.GetBlogListWithCategory();
            return View(values);
        }
        [AllowAnonymous]

        public IActionResult BlogReadAll(int id)

        {
            ViewBag.id = id;
            var value=blogManager.GetById(id);
            return View(value);
        }
        public IActionResult BlogListByWriter()
        {

            /* var mail = User.Identity.Name;
             var writer = writerManager.GetByMail(mail);
               */
            var username = User.Identity.Name;
            var writer = userManager.GetFilter(X => X.UserName == username);
                
        
            var values=blogManager.GetBlogListByWriter(writer.Id);
            return View(values);
        }
        [HttpGet]
        public IActionResult BlogAdd()
        {
            
            List<SelectListItem> categorys=(from item in categoryManager.GetAll()
                                            select new SelectListItem
                                            {

                                                Text=item.CategoryName,
                                                Value=item.CategoryID.ToString()
                                            }).ToList();

            ViewBag.categorysV = categorys;
            return View();
        }
        [HttpPost]
        public IActionResult BlogAdd(Blog blog)
        {
            var username = User.Identity.Name;
            // var writer = writerManager.GetByMail(mail);
            var user = userManager.GetFilter(x => x.UserName == username);
            BlogValidator validationRules = new BlogValidator();
                ValidationResult result = validationRules.Validate(blog);
                if (result.IsValid)
                {
                        blog.BlogStatus = true;
                        blog.BlogCreateDate = DateTime.Parse(DateTime.Now.ToShortDateString());
                       // blog.WriterID = writer.WriterID;
                        blog.AppUserID=user.Id;
                        blogManager.Add(blog);

                        return RedirectToAction("BlogListByWriter", "Blog");

                }
                else
                {
                    foreach (var item in result.Errors)
                    {
                        ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                    }
                }
                return View();

        }
        public IActionResult BlogDelete(int id)
        {
        
            var bul=blogManager.GetById(id);
            blogManager.Delete(bul);
            return RedirectToAction("BlogListByWriter", "Blog");

        }
        [HttpGet]
        public IActionResult BlogEdit(int id)
        {
            var blog=blogManager.GetById(id);

            List<SelectListItem> categorys = (from item in categoryManager.GetAll()
                                              select new SelectListItem
                                              {

                                                  Text = item.CategoryName,
                                                  Value = item.CategoryID.ToString()
                                              }).ToList();

            ViewBag.categorysV = categorys;
            return View(blog);
        }
        [HttpPost]
        public IActionResult BlogEdit(Blog b)
        {
            var username = User.Identity.Name;
            //  var writer = writerManager.GetByMail(mail);
            var user = userManager.GetFilter(x => x.UserName == username);
            b.AppUserID = user.Id;
            b.BlogStatus = true;
            blogManager.Update(b);
            return RedirectToAction("BlogListByWriter", "Blog");
        }

    }
}
