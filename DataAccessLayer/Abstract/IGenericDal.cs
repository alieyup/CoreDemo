﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
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

        //Blog Detay kısmı
        List<T> GetListAll(Expression<Func<T, bool>> filter);
    }
}
