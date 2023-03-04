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

		public void BlogAdd(Blog blog)
        {
            throw new NotImplementedException();
        }

        public void BlogRemove(Blog blog)
        {
            throw new NotImplementedException();
        }

        public void BlogUpdate(Blog blog)
        {
            throw new NotImplementedException();
        }

        public List<Blog> GetAllBlogs()
        {
            return _blogDal.GetListAll();
        }
        public List<Blog> GetLast3Blog()
        {
            //SON 3 KAYDI GETİRME BÖLÜMÜ
            return _blogDal.GetListAll().Take(3).ToList();
        }
        public List<Blog> GetBlogByID(int id)
        {
            return _blogDal.GetListAll(x => x.BlogID == id);
        }

		public List<Blog> GetBlogListByWriter(int id)
		{
			return _blogDal.GetListAll(x => x.WriterID == id);
		}

		public Blog GetById(int id)
        {
           throw new NotImplementedException();
        }
       
    }
}
