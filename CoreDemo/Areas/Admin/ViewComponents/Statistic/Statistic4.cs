using BusinessLayer.Concrete;
using DataAcessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace CoreDemo.Areas.Admin.ViewComponents.Statistic
{
    public class Statistic4:ViewComponent
    {
        AdminManager adminManager= new AdminManager(new EfAdminRepository());
        public IViewComponentResult Invoke()
        {
            var admin = adminManager.GetById(1);
            ViewBag.img =admin .ImageUrl;
            ViewBag.name=admin.Name;
            ViewBag.username=admin.UserName;
            ViewBag.description=admin.ShortDescription;
            return View();
        }
    }
}
