using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFreamwork;
using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;

namespace CoreDemo.Areas.Admin.ViewComponents.Statistic
{
    public class Statistic1 : ViewComponent
    {
        BlogManager bm = new BlogManager(new EfBlogRepository());
        Context context = new Context();
        public IViewComponentResult Invoke()
        {
            ViewBag.BlogCount = bm.GetList().Count();
            ViewBag.MessageCount = context.Message2s.Count();
            ViewBag.CommentCount = context.Comments.Count();

            string api = "3787e8ae13aaa593347e31a4e45380b4";
            string sehir = "Ankara";
            string connection = "https://api.openweathermap.org/data/2.5/weather?q=" + sehir + ",tr&mode=xml&lang=tr&units=metric&appid=" + api;
            XDocument document = XDocument.Load(connection);
            ViewBag.sicaklik = document.Descendants("temperature").ElementAt(0).Attribute("value").Value;
            ViewBag.sehir = sehir;
            return View();
        }
    }
}
