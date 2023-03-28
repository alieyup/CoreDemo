using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFreamwork;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Reflection.Metadata;

namespace CoreDemo.Controllers
{
    public class BlogController : Controller
    {
        BlogManager bm = new BlogManager(new EfBlogRepository());
        CategoryManager cm = new CategoryManager(new EfCategoryRepository());
        public IActionResult Index()
        {
            var values = bm.GetList();  
            return View(values);
        }
		public IActionResult BlogReadAll(int id)
		{
            ViewBag.i = id;
            var values = bm.GetBlogByID(id);
			return View(values);
		}
        public IActionResult BlogListByWriter()
        {
         var values=   bm.GetListCategoryByWriterBm(1);
			//var values = bm.GetBlogListByWriter(1);
			return View(values);
        }
        [HttpGet]
        public IActionResult BlogAdd()
        {
           List<SelectListItem> categoryvalues=(from x in cm.GetList()
                                                 select new SelectListItem
                                                 {
                                                     Text = x.CategoryName,
                                                     Value= x.CategoryID.ToString(),
                                                 }).ToList();
            ViewBag.cv = categoryvalues;
            return View();
        }

        [HttpPost]
        public IActionResult BlogAdd(Blog p)
        {
            BlogValidator bv = new BlogValidator();
            ValidationResult results = bv.Validate(p);

            List<SelectListItem> categoryvalues = (from x in cm.GetList()
                                                   select new SelectListItem
                                                   {
                                                       Text = x.CategoryName,
                                                       Value = x.CategoryID.ToString(),
                                                   }).ToList();
            ViewBag.cv = categoryvalues;
            if (results.IsValid)
            {
                p.BlogStatus = true;
                p.BlogCreateDate = DateTime.Parse(DateTime.Now.ToShortDateString());
                p.BlogThumbnailImage = "/image/1.jpg";
                p.WriterID=1;
                bm.TAdd(p);
                return RedirectToAction("BlogListByWriter", "Blog");
            }
            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
        }

        public IActionResult DeleteBlog(int id)
        {
            var blogvalue = bm.TGetById(id);
            bm.TRemove(blogvalue);
            return RedirectToAction("BlogListByWriter");
        }
        [HttpGet]
        public IActionResult EditBlog(int id)
        {
            var blogvalue=bm.TGetById(id);
            List<SelectListItem> categoryvalues = (from x in cm.GetList()
                                                   select new SelectListItem
                                                   {
                                                       Text = x.CategoryName,
                                                       Value = x.CategoryID.ToString(),
                                                   }).ToList();
            ViewBag.cv = categoryvalues;
            return View(blogvalue);
        }
        [HttpPost]
        public IActionResult EditBlog(Blog p)
        {
            var blogToUpdate = bm.TGetById(p.BlogID);
            p.WriterID = blogToUpdate.WriterID;
            p.BlogCreateDate = blogToUpdate.BlogCreateDate;
            p.BlogStatus = blogToUpdate.BlogStatus;
            bm.TUpdate(p);
            return RedirectToAction("BlogListByWriter");
        }

        public JsonResult JsonResultBlogReadAll()
        {
            return Json(bm.GetList());
        }

	}
}
