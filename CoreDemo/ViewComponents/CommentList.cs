using CoreDemo.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace CoreDemo.ViewComponents
{
    public class CommentList:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            List<UserComment> users = new List<UserComment>()
            { new UserComment(1,"Ali"), new UserComment(2,"Ayşe"), new UserComment(3,"Emel")};
            return View(users);
        }
    }
}
