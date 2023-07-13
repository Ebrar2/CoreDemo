using BusinessLayer.Concrete;
using DataAcessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace CoreDemo.Controllers
{
	public class NewsLetterController : Controller
	{

		NewsLetterManager _newsletterManager = new NewsLetterManager(new EfNewsLetterRepository());
        [HttpGet]
        public PartialViewResult NewsLetterAdd()
        {
            return PartialView();
        }

        [HttpPost]
        public IActionResult NewsLetterAdd(NewsLetter newsLetter)
        {
            newsLetter.MailStatus = true;
            _newsletterManager.NewsLetterAdd(newsLetter);
            return RedirectToAction("Index","Blog");
        }

    }
}
