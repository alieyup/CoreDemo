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
    public class BlogManager : IBlogService
    {
        IBlogDal _blogDal;
        public BlogManager(IBlogDal blogDal)
        {
            _blogDal = blogDal;
        }
   
        public List<Blog> GetLast3Blog()
        {
            //SON 3 KAYDI GETİRME BÖLÜMÜ
            return _blogDal.GetListAll().Take(3).ToList();
        }
		public List<Blog> GetBlogListByWriter(int id)
		{
			return _blogDal.GetListAll(x => x.WriterID == id);
		}
        public List<Blog> GetBlogByID(int id)
        {
            return _blogDal.GetListAll(x => x.BlogID == id);
        }
		public Blog GetById(int id)
        {
            //return _blogDal.GetListAll(x => x.BlogID == id);
            throw new NotImplementedException();
        }

        public List<Blog> GetBlogListWithCategory()
        {
            return _blogDal.GetListWithCategory();
        }
        public List<Blog> GetListCategoryByWriterBm(int id)
        {
            return _blogDal.GetlistWithCategoryByWriter(id);
		}
		public void TAdd(Blog t)
        {
            _blogDal.Add(t);
        }

        public void TRemove(Blog t)
        {
            throw new NotImplementedException();
        }

        public void TUpdate(Blog t)
        {
            throw new NotImplementedException();
        }

        public List<Blog> GetList()
        {
            return _blogDal.GetListAll();
        }
    }
}