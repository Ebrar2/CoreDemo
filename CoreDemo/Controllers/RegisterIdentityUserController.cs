﻿using CoreDemo.Models;
using DocumentFormat.OpenXml.Office.CustomUI;
using DocumentFormat.OpenXml.Office2021.DocumentTasks;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CoreDemo.Controllers
{
    [AllowAnonymous]
    public class RegisterIdentityUserController : Controller
    {
        private readonly UserManager<AppUser> userManager;
        public RegisterIdentityUserController(UserManager<AppUser> userManager)
        {
            this.userManager = userManager;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task< IActionResult> Index(UserSignUpViewModel userCreate)
        {
         
            if (ModelState.IsValid)
            {
                AppUser user = new AppUser()
                {
                   Email=userCreate.Mail,
                   NameSurname=userCreate.NameSurname,
                   UserName=userCreate.UserName
                    

                };
                var result = await userManager.CreateAsync(user, userCreate.Password);
                if(result.Succeeded)
                {
                    return RedirectToAction("Index", "Login");
                }
                else
                {
                    foreach (var item in result.Errors)
                    {
                        ModelState.AddModelError("", item.Description);
                    }
                }
            }
            return View(userCreate);
        }
    }
}
