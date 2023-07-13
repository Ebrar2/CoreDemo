using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAcessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata;
using System;
using X.PagedList;
using FluentValidation.Results;

namespace CoreDemo.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        CategoryManager categoryManager = new CategoryManager(new EfCategoryRepository());
        public IActionResult Index(int page=1)
        {
            var values= categoryManager.GetAll().ToPagedList(page,3); 
            return View(values);
        }

        [HttpGet]
        public IActionResult AddCategory()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddCategory(Category category)
        {
            CategoyValidator validationRules = new CategoyValidator();
            ValidationResult result = validationRules.Validate(category);
            if (result.IsValid)
            {
                category.CategoryStatus = true;

                categoryManager.Add(category);

                return RedirectToAction("Index", "Category");

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
        public IActionResult DeleteCategory(int id)
        {
            var category=categoryManager.GetById(id);
            categoryManager.Delete(category);
            return RedirectToAction("Index");
        }
    }
}
