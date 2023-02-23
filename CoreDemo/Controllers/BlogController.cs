﻿using BusinessLayer.Concrete;
using DataAccessLayer.EntityFreamwork;
using Microsoft.AspNetCore.Mvc;

namespace CoreDemo.Controllers
{
    public class BlogController : Controller
    {
        BlogManager bm = new BlogManager(new EfBlogRepository());
        public IActionResult Index()
        {
            var values = bm.GetAllBlogs();  
            return View(values);
        }
		public IActionResult BlogReadAll(int id)
		{
            var values = bm.GetBlogByID(id);
			return View(values);
		}
        public JsonResult JsonResultBlogReadAll()
        {
            return Json(bm.GetAllBlogs());
        }
	}
}
