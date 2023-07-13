using BusinessLayer.Concrete;
using DataAcessLayer.Concrete;
using DataAcessLayer.EntityFramework;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace CoreDemo.Controllers
{
    [Authorize]

    public class DashboardController : Controller
    {
        UserManager userManager = new UserManager(new EfUserRepository());

        public IActionResult Index()
        {
           
            Context context=new Context();
            var username = User.Identity.Name;
            var user = userManager.GetFilter(x => x.UserName == username);
            var usermail = user.Email;
            var writerid = user.Id;
            ViewBag.blogSize = context.Blogs.Count();
            ViewBag.writerBlogSize = context.Blogs.Where(x => x.AppUserID == writerid).Count();
            ViewBag.categorySize=context.Categories.Count();
            return View();
        }
    }
}
