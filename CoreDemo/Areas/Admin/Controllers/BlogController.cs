using ClosedXML.Excel;
using CoreDemo.Areas.Admin.Models;
using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System.Xaml.Permissions;

namespace CoreDemo.Areas.Admin.Controllers
{
        [Area("Admin")]
    public class BlogController : Controller
    {
        public IActionResult ExportStaticExcelBlogList()
        {
            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("Blog Listesi");
                worksheet.Cell(1, 1).Value = "Blog ID";
                worksheet.Cell(1, 2).Value = "Blog Adı";
                int BlogRowCount = 2;
                foreach (var item in GetBlogList())
                {
                    worksheet.Cell(BlogRowCount, 1).Value = item.ID;
                    worksheet.Cell(BlogRowCount, 2).Value = item.BlogName;
                    BlogRowCount++;
                }
                using (var stream= new MemoryStream())
                {
                    workbook.SaveAs(stream);
                    var content=stream.ToArray();
                    return File(content, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Calisma1.xlsx");
                }
            }
        }
        public List<BlogModel> GetBlogList()
        {
            List<BlogModel> bm = new List<BlogModel>
            {
                new BlogModel{ID=1,BlogName="Merhaba bu bir blog ismidir" },
                new BlogModel{ID=2,BlogName="2020 yılı olimpiyatları" },
                new BlogModel{ID=3,BlogName="Tesla Firmasının yeni kamyonları" }
            };
            return bm;
        }
        public IActionResult BlogListExcel()
        {
            return View();
        }

        public IActionResult ExportDinamikExcelBlogList()
        {
            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("Blog Listesi");
                worksheet.Cell(1, 1).Value = "Blog ID";
                worksheet.Cell(1, 2).Value = "Blog Adı";
                int BlogRowCount = 2;
                foreach (var item in BlogTitleList())
                {
                    worksheet.Cell(BlogRowCount, 1).Value = item.ID;
                    worksheet.Cell(BlogRowCount, 2).Value = item.BlogName;
                    BlogRowCount++;
                }
                using (var stream = new MemoryStream())
                {
                    workbook.SaveAs(stream);
                    var content = stream.ToArray();
                    return File(content, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Kitap.xlsx");
                }
            }
        }
        public List<BlogModelDinamik> BlogTitleList()
        {
            List<BlogModelDinamik> bmd = new List<BlogModelDinamik>();
            using(var c = new Context())
            {
                bmd = c.Blogs.Select(x => new BlogModelDinamik
                {
                    ID = x.BlogID,
                    BlogName=x.BlogTitle
                }).ToList();
            }
            return bmd;
        }
        public IActionResult BlogTitleListExcel()
        {
            return View();
        }
    }
}
