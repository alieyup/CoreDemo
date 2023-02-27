using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFreamwork;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;

namespace CoreDemo.Controllers
{
	public class RegisterController : Controller
	{
		WriterManager wm = new WriterManager(new EfWriterRepository());


		[HttpGet]
		public IActionResult Index()
		{
			return View();
		}

		/*Ekleme işlemi yapılırken HttpPost ve HttpGet attributelerin tanımlandığı metodların isimleri aynı olmak zorundadır. 
		HttpGet - Sayfa yüklenince
		HttpPost - Sayfada Buton tetiklenince

		Mesela HttpGet Attribute komutu sayfada kategorize veya benzeri işlemler kullanılırken sayfa yüklendiği anda listelenen niteliklerde kullanılabilir 
		Örn: İller / İlçeler HttpGet Attribute içiresine yazılabilir.
		     Kategoriler/AltKategoriler HttpGet Attribute içiresine yazılabilir.
		*/

		[HttpPost]
		public IActionResult Index(Writer p)
		{
			WriterValidator wv= new WriterValidator();
			ValidationResult results=wv.Validate(p);
			if (results.IsValid)
			{
			p.WriterStatus = true;
			p.WriterAbout = "Deneme Test";
			wm.WriterAdd(p);
			return RedirectToAction("Index", "Blog");
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
	}
}
