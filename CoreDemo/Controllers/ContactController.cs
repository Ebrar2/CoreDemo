using BusinessLayer.Concrete;
using DataAcessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;

namespace CoreDemo.Controllers
{

    [AllowAnonymous]
    public class ContactController : Controller
    {
        ContactManager contactManager = new ContactManager(new EfContactRepository());
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(Contact contact)
        {
            contact.ContactStatus = true;
            contact.ContactDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            
            contactManager.ContactAdd(contact);
            return RedirectToAction("Index", "Blog");
        }
    }
}
