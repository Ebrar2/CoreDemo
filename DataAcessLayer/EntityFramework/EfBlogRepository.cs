using DataAcessLayer.Abstract;
using DataAcessLayer.Concrete;
using DataAcessLayer.Repositories;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAcessLayer.EntityFramework
{
    public class EfBlogRepository : GenericRespository<Blog>, IBlogDal
    {
        public List<Blog> GetListWithCategory()
        {
            using var c = new Context();
            return c.Blogs.Include(x => x.Category).ToList();
}
        public List<Blog> GetListWithCategory(int id)
        {
            using var c = new Context();
            return c.Blogs.Include(x => x.Category).Where(x=>x.WriterID==id).ToList();
        }


    }
}
