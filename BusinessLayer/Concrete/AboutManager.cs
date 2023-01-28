using BusinessLayer.Abstract;
using DataAcessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
	public class AboutManager : IAboutService
	{
		IAboutDal dal;

		public AboutManager(IAboutDal dal)
		{
			this.dal = dal;
		}

		public void Add(About t)
		{
			throw new NotImplementedException();
		}

		public void Delete(About t)
		{
			throw new NotImplementedException();
		}

		public List<About> GetAll()
		{
            return dal.GetListAll();
        }

       
		public About GetById(int id)
		{
			throw new NotImplementedException();
		}

		public void Update(About t)
		{
			throw new NotImplementedException();
		}
	}
}
