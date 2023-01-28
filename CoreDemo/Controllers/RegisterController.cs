using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using CoreDemo.Models;
using DataAcessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System.Collections.Generic;
using System.Linq;

namespace CoreDemo.Controllers
{
	public class RegisterController : Controller
	{
		WriterManager writerManager = new WriterManager(new EfWriterRepository());
		[HttpGet]
		public IActionResult Index()
		{
	
			return View();
		}
		[HttpPost]
		public IActionResult Index(Writer writer)
		{
            WriterValidator validationRules = new WriterValidator();
			ValidationResult result=validationRules.Validate(writer);
			if(result.IsValid)
			{
			        writer.WriterStatus = true;
					writer.WriterAbout = "deneme";
					writerManager.Add(writer);	
				return RedirectToAction("Index", "Blog"); 

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
    }
}
