using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace CoreDemo.Areas.Admin.ViewComponents.Statistic
{
    public class Statistic4 : ViewComponent
    {
        Context context = new Context();
        public IViewComponentResult Invoke()
        {
            ViewBag.AdminIsim = context.Admins.Where(x => x.AdminID == 2).Select(x => x.Name).FirstOrDefault();
            ViewBag.ShortDesc = context.Admins.Where(x => x.AdminID == 2).Select(x => x.ShortDescription).FirstOrDefault();
            ViewBag.Image = context.Admins.Where(x => x.AdminID == 2).Select(x => x.ImageURL).FirstOrDefault();

            return View();
        }
    }
}
