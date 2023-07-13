using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using CoreDemo.Models;
using DataAcessLayer.Concrete;
using DataAcessLayer.EntityFramework;
using DocumentFormat.OpenXml.EMMA;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using System.Linq;
using System.Reflection.Metadata;
using System.Threading.Tasks;

namespace CoreDemo.Controllers
{
    public class WriterController : Controller
    {
        WriterManager writerManager = new WriterManager(new EfWriterRepository());
        UserManager userManager = new UserManager(new EfUserRepository());
        private readonly UserManager<AppUser> _userManager;


        public  WriterController(UserManager<AppUser> userManager)
            {
             _userManager = userManager;
            }
        [Authorize]
		public IActionResult Index()
		{
            var userName = User.Identity.Name;
            ViewBag.usM = userName;
            /* 
             Context c = new Context();
             var writerName=c.Writer.Where(x=>x.WriterMail==userMail).Select(x=>x.WriterName).FirstOrDefault();*/

            ViewBag.writerName = userManager.GetFilter(x => x.UserName == userName);
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
        public async Task<IActionResult> WriterEditsProfile()
        {
            /*  1.yol
             * Context c = new Context();
             var username = User.Identity.Name;
             var mail=c.Users.Where(x=>x.UserName==username).Select(z=>z.Email).FirstOrDefault();
             var writer = writerManager.GetByMail(mail);*/
         /*  
          *  2.yol
          *  var username = User.Identity.Name;
            var id = c.Users.Where(x => x.UserName == username).Select(z => z.Id).FirstOrDefault();
            
            var writer = userManager.GetById(id);*/

           var writer = await _userManager.FindByNameAsync(User.Identity.Name);
            UserUpdateViewModel userUpdateView = new UserUpdateViewModel();
            userUpdateView.UserName = writer.UserName;
            userUpdateView.ImageUrl = writer.ImageUrl;
            userUpdateView.NameSurname = writer.NameSurname;
            userUpdateView.Mail = writer.Email;
            return View(userUpdateView);

        }
        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> WriterEditsProfile(UserUpdateViewModel userUpdateViewModel)
        {
               
               var user=await _userManager.FindByNameAsync(User.Identity.Name);
            if (userUpdateViewModel.changePassword)
            {
                user.PasswordHash = _userManager.PasswordHasher.HashPassword(user, userUpdateViewModel.Password);

            }
                user.NameSurname = userUpdateViewModel.NameSurname;
                user.Email = userUpdateViewModel.Mail;
                user.ImageUrl = userUpdateViewModel.ImageUrl;
            


            var result = await _userManager.UpdateAsync(user);
            if (result.Succeeded)
            {
                return RedirectToAction("Index", "Dashboard");

            }
            else
            {
                return View(userUpdateViewModel);
            }




        }
        /*      public IActionResult WriterEditsProfile(Writer writer)
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

              }*/
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
       
    }
}
