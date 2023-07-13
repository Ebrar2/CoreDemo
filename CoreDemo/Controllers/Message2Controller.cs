using BusinessLayer.Concrete;
using CoreDemo.Models;
using DataAcessLayer.EntityFramework;
using DocumentFormat.OpenXml.Wordprocessing;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;

namespace CoreDemo.Controllers
{
    public class Message2Controller : Controller
    {
        Message2Manager messageManager = new Message2Manager(new EfMessage2Repository());
        UserManager userManager = new UserManager(new EfUserRepository());
        public IActionResult Index()
        {
            var username=User.Identity.Name;
            var user = userManager.GetFilter(x => x.UserName == username);
            var messages = messageManager.GetInboxListByWriter(user.Id);
            return View(messages);
        }

        public IActionResult MessageDetails(int id)
        {
            var value=messageManager.GetById(id);
            return View(value);
        }
        public IActionResult SendBox()
        {
            var username = User.Identity.Name;
            var user = userManager.GetFilter(x => x.UserName == username);
            var messages = messageManager.GetSendListByWriter(user.Id);
            return View(messages);
        
    }

        [HttpGet]
        public IActionResult SendMessage()
        {
            return View();
        }
        [HttpPost]
        public IActionResult SendMessage(MessageSendViewModel message2)
        {

            var username = User.Identity.Name;
            var user = userManager.GetFilter(x => x.UserName == username);

            Message2 message = new Message2();
            message.SenderID = user.Id;
            var receiver = userManager.GetFilter(x => x.Email == message2.ReceiverMail);
            if(receiver != null)
            {
                message.ReceiverID = receiver.Id;
                message.MessageDateTime = Convert.ToDateTime(DateTime.Now.ToShortDateString());
                message.MessageStatus = true;
                message.Subject = message2.Subject;
                message.MessageDetails = message2.MessageDetails;
                messageManager.Add(message);
                return RedirectToAction("SendBox", "Message2");

            }


            return View();
            





        }

    }
}
