using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class CategoryManager : ICategoryService
    {
        ICategoryDal _categoryDal;
        public CategoryManager(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }
        public void TAdd(Category t)
        {
            _categoryDal.Add(t);
        }

        public void TRemove(Category t)
        {
            _categoryDal.Remove(t);
        }

        public void TUpdate(Category t)
        {
            _categoryDal.Update(t);
        }
        public List<Category> GetList()
        {
            return _categoryDal.GetListAll();
        }
        public Category TGetById(int id)
        {
            return _categoryDal.GetById(id);
        }
    }
}