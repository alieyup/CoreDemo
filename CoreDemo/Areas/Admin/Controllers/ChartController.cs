using CoreDemo.Areas.Admin.Models;
using Microsoft.AspNetCore.Mvc;

namespace CoreDemo.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ChartController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult CategoryChart()
        {
            List<CategoryClas> list = new List<CategoryClas>();
            list.Add(new CategoryClas 
            { 
                categoryname = "Yazılım",  
                categorycount = 10 
            });
            list.Add(new CategoryClas
            {
                categoryname = "Teknoloji",
                categorycount = 7
            });
            list.Add(new CategoryClas
            {
                categoryname = "Spor",
                categorycount = 19
            });
            return Json(new { jsonlist = list });
        }
    }
}
