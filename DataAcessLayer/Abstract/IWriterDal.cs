﻿using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAcessLayer.Abstract
{
    public interface IWriterDal:IGenericDal<Writer>
    {
        public Writer GetByMail(string mail);
    }
}
