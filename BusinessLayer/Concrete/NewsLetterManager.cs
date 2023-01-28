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
	public class NewsLetterManager : INewsLetterService
	{
		INewsLetterDal newsLetterDal;

		public NewsLetterManager(INewsLetterDal newsLetterDal)
		{
			this.newsLetterDal = newsLetterDal;
		}

		public void NewsLetterAdd(NewsLetter newsLetter)
		{
			newsLetterDal.Insert(newsLetter);
		}
	}
}
