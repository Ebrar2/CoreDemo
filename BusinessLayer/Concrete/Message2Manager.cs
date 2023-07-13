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
    public class Message2Manager : IMessage2Service
    {
        IMessage2Dal message2Dal;

        public Message2Manager(IMessage2Dal message2Dal)
        {
            this.message2Dal = message2Dal;
        }

        public void Add(Message2 t)
        {
            throw new NotImplementedException();
        }

        public void Delete(Message2 t)
        {
            throw new NotImplementedException();
        }

        public List<Message2> GetAll()
        {
            throw new NotImplementedException();
        }

        public Message2 GetById(int id)
        {
            return message2Dal.GetById(id);
        }

        public List<Message2> GetInboxListByWriter(int id)
        {
           return message2Dal.GetListWithWriter(id);
        }

    

        public void Update(Message2 t)
        {
            throw new NotImplementedException();
        }
    }
}
