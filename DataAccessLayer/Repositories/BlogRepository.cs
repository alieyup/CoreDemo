using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
    public class BlogRepository : IBlogDal
    {


        public Blog GetById(int id)
        {
            using (var c = new Context())
            {
                return c.Blogs.Find(id); 
            }
        }

        public void RemoveBlog(Blog blog)
        {
            using var c = new Context();
            c.Remove(blog);
            c.SaveChanges();
        }

        public void Add(Blog t)
        {
            using var c = new Context();
            c.Add(t);
            c.SaveChanges();
        }

        public void Remove(Blog t)
        {
            throw new NotImplementedException();
        }

        public void Update(Blog t)
        {
            using var c = new Context();
            c.Update(t);
            c.SaveChanges();
        }

        public List<Blog> GetListAll()
        {
            using var c = new Context();
            return c.Blogs.ToList();
        }

		public List<Blog> GetListAll(Expression<Func<Blog, bool>> filter)
		{
			throw new NotImplementedException();
		}
	}
}
