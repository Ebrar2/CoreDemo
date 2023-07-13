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
    public class MessageManager : IMessageService
    {
        IMessageDal messageDal;
        public MessageManager(IMessageDal messageDal)
        {
            this.messageDal = messageDal;
        }

        public void Add(Message t)
        {
            
        }

        public void Delete(Message t)
        {
            throw new NotImplementedException();
        }

        public List<Message> GetAll()
        {
            return messageDal.GetListAll();
        }

        public List<Message> GetInboxListByWriter(String p)

        {

            return messageDal.GetListAll(x => x.Receiver==p);

        }

        public Message GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Message t)
        {
            throw new NotImplementedException();
        }
    }
}
