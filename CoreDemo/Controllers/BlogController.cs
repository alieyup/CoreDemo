using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFreamwork;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;

namespace CoreDemo.Controllers
{
    public class BlogController : Controller
    {
        BlogManager bm = new BlogManager(new EfBlogRepository());
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
         var values=   bm.GetBlogListByWriter(1);
            return View(values);
        }
        [HttpGet]
        public IActionResult BlogAdd()
        {
            return View();
        }
        [HttpPost]
        public IActionResult BlogAdd(Blog p)
        {
            BlogValidator bv = new BlogValidator();
            ValidationResult results = bv.Validate(p);
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


        public JsonResult JsonResultBlogReadAll()
        {
            return Json(bm.GetList());
        }

	}
}
