using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using CoreDemo.Models;
using DataAcessLayer.Concrete;
using DataAcessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using System.Linq;
using System.Reflection.Metadata;

namespace CoreDemo.Controllers
{
	public class WriterController : Controller
	{
        WriterManager writerManager = new WriterManager(new EfWriterRepository());
        [Authorize]
		public IActionResult Index()
		{
            var userMail = User.Identity.Name;
            ViewBag.usM = userMail;
            Context c = new Context();
            var writerName=c.Writer.Where(x=>x.WriterMail==userMail).Select(x=>x.WriterName).FirstOrDefault();
            ViewBag.writerName=writerName;
            return View();
		}
        public IActionResult WriterProfile()
        {
            return View();
        }
        public IActionResult WriterMail()
        {
            return View();
        }
        [AllowAnonymous]
        public IActionResult Test()
        {
            return View();
        }
        public PartialViewResult WriterNavbar()
        {
            return  PartialView();
        }
        [AllowAnonymous]
        public PartialViewResult WriterFooterPartial()
        {
            return PartialView();
        }

        [AllowAnonymous]
        [HttpGet]
        public IActionResult WriterEditsProfile()
        {

            var username = User.Identity.Name;
            var writer = writerManager.GetByMail(username);
            return View(writer);

        }
        [AllowAnonymous]
        [HttpPost]
        public IActionResult WriterEditsProfile(Writer writer)
        {

             WriterValidator validator = new WriterValidator();
             ValidationResult validationResult = validator.Validate(writer);
            if(validationResult.IsValid)
            {
                 
                writerManager.Update(writer);
                return RedirectToAction("Index","Dashboard");
            }
           else
            {
                foreach (var item in validationResult.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();

        }
        [AllowAnonymous]
        [HttpGet]
        public IActionResult WriterAdd()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        public IActionResult WriterAdd(AddWriter addWriter)
        {
            Writer wri = new Writer();
            if(addWriter != null)
            {
                var extension = Path.GetExtension(addWriter.WriterImage.FileName);
                //DOSYA UZANTI
                var newimagename = Guid.NewGuid() + extension;
                var location = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/WriterImageFiles/", newimagename);
               var stream=new FileStream(location, FileMode.Create);
                addWriter.WriterImage.CopyTo(stream);
                wri.WriterImage = newimagename;
            }
            wri.WriterID = addWriter.WriterID;
            wri.WriterName = addWriter.WriterName;
            wri.WriterPassword = addWriter.WriterPassword;
            wri.WriterStatus = true;
            wri.WriterAbout = addWriter.WriterAbout;
            wri.WriterMail = addWriter.WriterMail;
            WriterValidator validator = new WriterValidator();
            ValidationResult validationResult = validator.Validate(wri);
            if (validationResult.IsValid)
            {

                writerManager.Add(wri);
                return RedirectToAction("Index", "Dashboard");
            }
            else
            {
                foreach (var item in validationResult.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
          
        }
        public IActionResult Deneme()
        {
            return View();
        }
    
    }
}
