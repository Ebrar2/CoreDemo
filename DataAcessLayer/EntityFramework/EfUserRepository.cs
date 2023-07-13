using DataAcessLayer.Abstract;
using DataAcessLayer.Concrete;
using DataAcessLayer.Repositories;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAcessLayer.EntityFramework
{
    public class EfUserRepository : GenericRespository<AppUser>, IUserDal
    {
        public AppUser GetFilter(Expression<Func<AppUser, bool>> filter)
        {
            using var c = new Context();

            return c.Users.Where(filter).FirstOrDefault();  
        }
    }
}
