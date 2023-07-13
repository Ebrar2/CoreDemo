using BusinessLayer.Concrete;
using DataAcessLayer.Concrete;
using DataAcessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace CoreDemo.ViewComponents.Writer
{
    public class WriterAboutOnDashboard: ViewComponent
    {
        WriterManager writerManager = new WriterManager(new EfWriterRepository());
        public IViewComponentResult Invoke()
        {
            Context context = new Context();
            var userName=User.Identity.Name;
            var userMail = context.Users.Where(x=>x.UserName==userName).Select(x => x.Email).FirstOrDefault();
            var x = writerManager.GetByMail(userMail);


            return View(x);


        }

    }
}
