using BusinessLayer.Concrete;
using DataAcessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace CoreDemo.ViewComponents.Comment
{
    public class CommentListByBlog:ViewComponent
    {
       CommentManager commentManager= new CommentManager(new EfCommentRepository());
        public IViewComponentResult Invoke(int id)
        {
            var values = commentManager.GetListAll().Where(x=>x.BlogID==id).ToList();
            return View(values);
        }
    }
}
