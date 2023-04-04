using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using CoreDemo.Models;
using DataAccessLayer.EntityFreamwork;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CoreDemo.Controllers
{
	//burada olursa tüm sayfaları bağlar
	//[Authorize]
	public class WriterController : Controller
	{
		// burada olursa sadece o sayfayı bağlar [Authorize] giriş yapmasına izin vermez, önce login ister
		// giriş yapılmasına izin verir herkes girer. [AllowAnonymous]
		//[AllowAnonymous]
		WriterManager wm = new WriterManager(new EfWriterRepository());

		public IActionResult Index()
		{
			return View();
		}
		public IActionResult WriterProfile()
		{
			return View();
		}
		public IActionResult WriterMail()
		{
			return View();
		}
		public IActionResult Test() {
			return View();
		}
		public PartialViewResult WriterNavbarPartial()
		{
			return PartialView();
        }
        public PartialViewResult WriterFooterPartial()
        {
            return PartialView();
        }
		[HttpGet]
		public IActionResult WriterEditProfile()
		{
			var writervalues = wm.TGetById(1);
			return View(writervalues);
		}
		[HttpPost]
        public IActionResult WriterEditProfile(Writer p)
        {
			WriterValidator wl = new WriterValidator();
			ValidationResult result = wl.Validate(p);
			if (result.IsValid)
			{
				wm.TUpdate(p);
					return RedirectToAction("Index", "Dashboard");
			}
			else
			{
				foreach (var item in result.Errors)
				{
					ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
				}
			}
			return View();
        }

        [HttpGet]
        public IActionResult WriterAdd()
        {
            return View();
        }
        [HttpPost]
        public IActionResult WriterAdd(AddProfileImage p)
        {
			Writer w = new Writer();
			if (p.WriterImage!=null)
			{
				var extension = Path.GetExtension(p.WriterImage.FileName);
				var newimagename = Guid.NewGuid() + extension;
				var location = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/WriterImageFiles/", newimagename);
				var stream = new FileStream(location, FileMode.Create);
				p.WriterImage.CopyTo(stream);
				w.WriterImage = newimagename;
			}
			w.WriterMail = p.WriterMail;
			w.WriterName = p.WriterName;
			w.WriterPassword = p.WriterPassword;
			w.WriterStatus = true;
			w.WriterAbout = p.WriterAbout;
			wm.TAdd(w);
            return RedirectToAction("Index", "Dashboard");
        }
    }
}
