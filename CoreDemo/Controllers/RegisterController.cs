using BusinessLayer.Concrete;
using DataAccessLayer.EntityFreamwork;
using EntityLayer.Concrete;
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
			p.WriterStatus = true;
			p.WriterAbout = "Deneme Test";
			wm.WriterAdd(p);
			return RedirectToAction("Index", "Blog");
		}
	}
}
