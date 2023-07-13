using BusinessLayer.Abstract;
using DataAcessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class UserManager : IUserService
    {
        IUserDal userDal;
        public UserManager(IUserDal userDal)
        {
            this.userDal = userDal;
        }

        public void Add(AppUser t)
        {
            throw new NotImplementedException();
        }

        public void Delete(AppUser t)
        {
            throw new NotImplementedException();
        }

        public List<AppUser> GetAll()
        {
            throw new NotImplementedException();
        }

        public AppUser GetById(int id)
        {
            return userDal.GetById(id);
        }

        public AppUser GetFilter(Expression<Func<AppUser, bool>> filter)
        {
            return userDal.GetFilter(filter);
        }

        public void Update(AppUser t)
        {
            userDal.Update(t);
        }
    }
}
