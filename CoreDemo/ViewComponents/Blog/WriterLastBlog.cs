using BusinessLayer.Concrete;
using DataAcessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace CoreDemo.ViewComponents.Blog
{
	public class WriterLastBlog:ViewComponent
	{
		BlogManager blogManager=new BlogManager(new EfBlogRepository());
		public IViewComponentResult Invoke()
		{

			var values=blogManager.GetBlogListByWriter(2);

			return View(values);
		}
	}
}
