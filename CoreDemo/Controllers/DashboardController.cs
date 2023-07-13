using DataAcessLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace CoreDemo.Controllers
{
    [Authorize]

    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            Context context=new Context();
            ViewBag.blogSize = context.Blogs.Count();
            ViewBag.writerBlogSize = context.Blogs.Where(x => x.WriterID == 2).Count();
            ViewBag.categorySize=context.Categories.Count();
            return View();
        }
    }
}
