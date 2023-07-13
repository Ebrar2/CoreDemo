using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IUserService:IGenericService<AppUser>
    {
        public AppUser GetFilter(Expression<Func<AppUser, bool>> filter);
    }
}
