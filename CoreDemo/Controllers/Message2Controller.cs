using BusinessLayer.Concrete;
using DataAcessLayer.EntityFramework;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CoreDemo.Controllers
{
    public class Message2Controller : Controller
    {
        Message2Manager messageManager = new Message2Manager(new EfMessage2Repository());

        [AllowAnonymous]
        public IActionResult Index()
        {
            int id = 2;
            var messages = messageManager.GetInboxListByWriter(id);
            return View(messages);
        }

        [AllowAnonymous]
        public IActionResult MessageDetails(int id)
        {
            var value=messageManager.GetById(id);
            return View(value);
        }
    }
}
