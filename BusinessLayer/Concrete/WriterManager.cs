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
	public class WriterManager : IWriterService
	{
		IWriterDal writerDal;

		public WriterManager(IWriterDal writerDal)
		{
			this.writerDal = writerDal;
		}

		public void Add(Writer t)
		{
            writerDal.Insert(t);
        }

        public void Delete(Writer t)
		{
			throw new NotImplementedException();
		}

		public List<Writer> GetAll()
		{
			throw new NotImplementedException();
		}

		public Writer GetById(int id)
		{
			return writerDal.GetById(id);
		}

		public Writer GetByMail(string mail)
		{
			return writerDal.GetByMail(mail);
		}

		public void Update(Writer t)
		{
			writerDal.Update(t);
		}

		
	}
}
