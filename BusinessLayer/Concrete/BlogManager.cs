using BusinessLayer.Abstract;
using DataAcessLayer.Abstract;
using DataAcessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Server.IIS.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class BlogManager : IBlogService
    {

        IBlogDal blogDal;
        public BlogManager(IBlogDal blogDal)
        {
            this.blogDal = blogDal;
        }

        public List<Blog> GetBlogListWithCategory()
        {
           return blogDal.GetListWithCategory();
        }

        public List<Blog> GetLast3Blogs()
        {
            return blogDal.GetListAll().OrderByDescending(x=>x.BlogID).Take(3).ToList();
        }

        public List<Blog> GetBlogListByWriter(int id)
        {
            //return blogDal.GetListAll(x => x.WriterID == id);
            return blogDal.GetListWithCategory(id);
        }

        public void Add(Blog t)
        {
            blogDal.Insert(t);
        }

        public void Delete(Blog t)
        {
              blogDal.Delete(t);
        }

        public void Update(Blog t)
        {
            blogDal.Update(t);

        }

        public List<Blog> GetAll()
        {
            return blogDal.GetListAll();
        }

        public Blog GetById(int id)
        {
            return blogDal.GetById(id);
        }
    }
}
//public void BlogAdd(Blog blog)
//{
//    blogDal.Insert(blog); 
//}

//public void BlogDelete(Blog blog)
//{
//    blogDal.Delete(blog);
//}

//public void BlogUpdate(Blog blog)
//{
//    blogDal.Update(blog);
//}

//public List<Blog> GetBlogByID(int id)
//{
//    return blogDal.GetListAll(x => x.BlogID == id);
//}
//public Blog GetBlogById(int id)
//{
//    return blogDal.GetById(id);
//}
//public List<Blog> GetAllBlogs()
//{
//    return blogDal.GetListAll();
//}