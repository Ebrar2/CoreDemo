using BusinessLayer.Concrete;
using DataAcessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System;

namespace CoreDemo.Controllers
{
	public class CommentController : Controller
	{
		CommentManager _commentManager = new CommentManager(new EfCommentRepository());
		public IActionResult Index()
		{
			return View();
		}
		public PartialViewResult PartialAddComment()
		{
			return PartialView();	
		}

        public IActionResult CommentAdd(Comment comment)
        {
			comment.CommentDate = DateTime.Parse(DateTime.Now.ToShortDateString());
			comment.CommentStatus = true;
			comment.BlogID = 14;
			_commentManager.CommentAdd(comment);
            return RedirectToAction("Index","Blog");
        }

        public PartialViewResult CommentListByBlog(int id)
        {
			var values=_commentManager.GetList(id);
            return PartialView(values);
        }

    }
}
