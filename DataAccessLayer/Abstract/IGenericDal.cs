﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface IGenericDal<T> where T : class
    {
        void Add(T t);
        void Remove(T t);
        void Update(T t);
        List<T> GetListAll();
        T GetById(int id);
    }
}
