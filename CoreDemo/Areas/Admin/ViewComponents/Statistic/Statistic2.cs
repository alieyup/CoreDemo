using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System.Drawing;

namespace CoreDemo.Areas.Admin.ViewComponents.Statistic
{
    public class Statistic2 : ViewComponent
    {
        Context context = new Context();
        public IViewComponentResult Invoke()
        {
            var blogid = context.Blogs.OrderByDescending(x => x.BlogID).Select(x => x.WriterID).Take(1).FirstOrDefault();
            ViewBag.SonEklenenBlog = context.Blogs.OrderByDescending(x => x.BlogTitle).Select(x=>x.BlogTitle).Take(1).FirstOrDefault();
            ViewBag.SonBlogYazari = context.Writers.Where(x => x.WriterID == blogid).Select(x => x.WriterName).FirstOrDefault();
            return View();
        }
    }
}
