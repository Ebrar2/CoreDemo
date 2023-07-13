using DataAcessLayer.Abstract;
using DataAcessLayer.Concrete;
using DataAcessLayer.Repositories;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAcessLayer.EntityFramework
{
    public class EfWriterRepository : GenericRespository<Writer>, IWriterDal
    {
        public Writer GetByMail(string mail)
        {
            using var c = new Context();
            return c.Writer.Where(x => x.WriterMail == mail).FirstOrDefault();
        }
    }
}
