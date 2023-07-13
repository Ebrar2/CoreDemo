using BusinessLayer.Concrete;
using DataAcessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Xml.Linq;

namespace CoreDemo.Areas.Admin.ViewComponents.Statistic
{
    public class Statistic1 : ViewComponent
    {
        BlogManager blogManager = new BlogManager(new EfBlogRepository());
        ContactManager contact = new ContactManager(new EfContactRepository());
        CommentManager comment = new CommentManager(new EfCommentRepository()); 
        public IViewComponentResult Invoke()
        {


            ViewBag.v1 = blogManager.GetAll().Count;
            ViewBag.v2=contact.GetListAll().Count;
            ViewBag.v3=comment.GetListAll().Count;

            string api = "d8c87ece0fc1190176f6a2e89ccff241";
            string connection = "https://api.openweathermap.org/data/2.5/weather?q=istanbul&mode=xml&lang=tr&units=metric&appid=" + api;
            XDocument document = XDocument.Load(connection);
            ViewBag.v4=document.Descendants("temperature").ElementAt(0).Attribute("value").Value;
            return View();



        }
    }
}