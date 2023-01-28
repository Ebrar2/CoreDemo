using BusinessLayer.Abstract;
using DataAcessLayer.Abstract;
using DataAcessLayer.EntityFramework;
using DataAcessLayer.Repositories;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class CategoryManager : ICategoryService
    {

        ICategoryDal category;

        public CategoryManager(ICategoryDal category)
        {
            this.category = category;
        }

        public void Add(Category t)
        {
            category.Insert(t);
        }

        public void Delete(Category t)
        {
           category.Delete(t);
        }

        public List<Category> GetAll()
        {
            return category.GetListAll();
        }

        public Category GetById(int id)
        {
            return category.GetById(id);
        }

        public void Update(Category t)
        {
           category.Update(t);
        }

     

    }
}
