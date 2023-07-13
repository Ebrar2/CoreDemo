using CoreDemo.Areas.Admin.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace CoreDemo.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ChartController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult CategoryChart()
        {
            List<CategoryClass> categories = new List<CategoryClass>();

            categories.Add(new CategoryClass
            {
                categorycount = 10,
                categoryname = "Teknoloji"
            });
            categories.Add(new CategoryClass
            {
                categorycount=5,
                categoryname="Sanat"
            });
            categories.Add(new CategoryClass
            {
                categorycount = 12,
                categoryname = "Spor"
            });
            return Json( new {jsonlist=categories});

        }
    }
}
