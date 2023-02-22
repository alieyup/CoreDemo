﻿using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
    public class CategoryRepository : ICategoryDal
    {
        Context c = new Context();

        public void Add(Category category)
        {
            c.Add(category);
            c.SaveChanges();
        }
        public Category GetById(int id)
        {
          return  c.Categories.Find(id);
        }

        public List<Category> GetListAll()
        {
            return c.Categories.ToList();
        }

        public void Remove(Category category)
        {
            c.Remove(category);
            c.SaveChanges();
        }


        public void Update(Category category)
        {
            c.Update(category);
            c.SaveChanges();
        }

    }
}