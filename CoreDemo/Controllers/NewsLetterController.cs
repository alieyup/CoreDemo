using DataAccessLayer.EntityFreamwork;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using BusinessLayer.Concrete;

namespace CoreDemo.Controllers
{
	public class NewsLetterController : Controller
	{
		NewsLetterManager nm = new NewsLetterManager(new EfNewsLetterRepository());
		[HttpGet]
		public PartialViewResult SubscribeMail()
		{
			return PartialView();
		}
		[HttpPost]
		public PartialViewResult SubscribeMail(NewsLetter p)
		{
			p.MailStatus = true;
			nm.AddNewsLetter(p);
			return PartialView();
		}
		//[HttpPost]
		//public IActionResult SubscribeMail(NewsLetter p)
		//{
		//	p.MailStatus = true;
		//	nm.AddNewsLetter(p);
		//	Response.Redirect("/Blog/BlogReadAll/" + 1);
		//	return PartialView();
		//}
	}
}
