using CoreDemo.Models;
using DataAcessLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Server.IIS.Core;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace CoreDemo.Controllers
{
    [AllowAnonymous]

    public class LoginController : Controller
	{

		private readonly SignInManager<AppUser> _signInManager;
		public LoginController(SignInManager<AppUser> signInManager)
		{
			_signInManager = signInManager;
		}
		[HttpGet]
		public IActionResult Index()
		{
			return View();
		}
		[HttpPost]
		public async Task<IActionResult> Index(UserSignInViewModel signInViewModel)
		{
			if(ModelState.IsValid)
			{
				var result = await _signInManager.PasswordSignInAsync(signInViewModel.UserName, signInViewModel.Password, false, true);
				if(result.Succeeded)
				{
					return RedirectToAction("Index", "Dashboard");
				}
				else
				{
					
					return View(signInViewModel);
				}
			}
            return View(signInViewModel);
        }
		public async Task<IActionResult> LogOut()
		{
			await _signInManager.SignOutAsync();
			return RedirectToAction("Index", "Login");

		}


    }
}