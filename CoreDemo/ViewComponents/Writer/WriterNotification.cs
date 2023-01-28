using BusinessLayer.Concrete;
using DataAcessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace CoreDemo.ViewComponents.Writer
{
   
    public class WriterNotification : ViewComponent
    {
        NotificationManager notification = new NotificationManager(new EfNotificationRepository());
        public IViewComponentResult Invoke()
        {
            var values = notification.GetAll();
            return View(values);
        }

    }
}