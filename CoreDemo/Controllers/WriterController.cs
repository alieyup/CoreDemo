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
	}
}
