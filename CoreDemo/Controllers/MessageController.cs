﻿using BusinessLayer.Concrete;
using DataAccessLayer.EntityFreamwork;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CoreDemo.Controllers
{
	public class MessageController : Controller
	{
		Message2Manager mm = new Message2Manager(new EfMessage2Repository());
		public IActionResult InBox()
		{
			int id = 1;
			var values = mm.GetInboxListByWriter(id);
			return View(values);
		}
		[HttpGet]
		public IActionResult MessageDetails(int id)
		{
			var value = mm.TGetById(id);
			
			return View(value);
		}
	}
}
