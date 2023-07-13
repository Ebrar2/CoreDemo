using BusinessLayer.Concrete;
using DataAcessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace CoreDemo.Areas.Admin.ViewComponents.Statistic
{
    public class Statistic2:ViewComponent
    {
        BlogManager blogManager=new BlogManager(new EfBlogRepository());

         public IViewComponentResult Invoke()
        {

            ViewBag.title = blogManager.GetLast3Blogs().OrderByDescending(x => x.BlogID).Select(x => x.BlogTitle).FirstOrDefault();

           

            return View();



        }

    }
}
