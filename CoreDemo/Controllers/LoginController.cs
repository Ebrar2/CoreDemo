﻿using DataAcessLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Server.IIS.Core;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace CoreDemo.Controllers
{
	public class LoginController : Controller
	{

		[HttpGet]
		[AllowAnonymous]
		public IActionResult Index()
		{
			return View();
		}
		[HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Index(Writer writer)
        {
			Context context = new Context();
			var datavalue = context.Writer.Where(x => x.WriterMail == writer.WriterMail && x.WriterPassword == writer.WriterPassword).FirstOrDefault();
			if(datavalue!=null)
			{
				var claims = new List<Claim>
				{
					new Claim(ClaimTypes.Name,writer.WriterMail)

				};
				var useridentity=new ClaimsIdentity(claims,"a");	
				ClaimsPrincipal principal = new ClaimsPrincipal(useridentity);
				await HttpContext.SignInAsync(principal);
				return RedirectToAction("Index", "Writer");
			}
            return View();
        }
    }
}
