using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAcessLayer.Abstract
{
    public interface IMessage2Dal:IGenericDal<Message2>
    {
        List<Message2> GetInboxWithWriter(int id);
        List<Message2> GetSendByWriter(int id);
    }
}
