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
    public class ContactManager : IContactService
    {
        IContactsDal contactsDal;
        public ContactManager(IContactsDal contactsDal)
        {
           this.contactsDal = contactsDal;
        }

        public void ContactAdd(Contact contact)
        {
           contactsDal.Insert(contact);
        }
        public List<Contact> GetListAll()
        {
           return contactsDal.GetListAll();
        }
    }
}
