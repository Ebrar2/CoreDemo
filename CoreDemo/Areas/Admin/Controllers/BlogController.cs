using ClosedXML.Excel;
using CoreDemo.Areas.Admin.Models;
using DataAcessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace CoreDemo.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class BlogController : Controller
    {

        public IActionResult ExportStaticExcelBlogList()
        {
            using (var workbook = new XLWorkbook())
            {
                var sheet = workbook.Worksheets.Add("Blog Listesi");

                sheet.Cell(1, 1).Value = "Blog ID";
                sheet.Cell(1, 2).Value = "Blog ADI";

                int blogRowCount = 2;
                foreach (var item in GetByBlogList())
                {
                    sheet.Cell(blogRowCount, 1).Value = item.ID;
                    sheet.Cell(blogRowCount, 2).Value = item.BlogName;
                    blogRowCount++;
                }
                using (var stream = new MemoryStream())
                {
                    workbook.SaveAs(stream);
                    var content=stream.ToArray();
                    return File(content, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet","Calisma1.xlsx");
                }


            }

        }
        List<BlogModel> GetByBlogList()
        {
            List<BlogModel> list = new List<BlogModel>()
        {
            new BlogModel()
            {
                ID=1,BlogName="C# Programlamaya Giriş"
            },
             new BlogModel()
            {
                ID=2,BlogName="Tesla Araçlaro"
            },
             new BlogModel()
             {
                 ID=3,BlogName="2020 Olimpiyatları"
,             }

        };

            return list;
        }
        public IActionResult BlogListExcel()
        {
            return View();
        }
        public IActionResult ExportDynamicExcelBlogList()
        {
            using (var workbook = new XLWorkbook())
            {
                var sheet = workbook.Worksheets.Add("Blog Listesi");

                sheet.Cell(1, 1).Value = "Blog ID";
                sheet.Cell(1, 2).Value = "Blog ADI";

                int blogRowCount = 2;
                foreach (var item in GetAllBlogList())
                {
                    sheet.Cell(blogRowCount, 1).Value = item.ID;
                    sheet.Cell(blogRowCount, 2).Value = item.BlogName;
                    blogRowCount++;
                }
                using (var stream = new MemoryStream())
                {
                    workbook.SaveAs(stream);
                    var content = stream.ToArray();
                    return File(content, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Calisma1.xlsx");
                }


            }

        }
        public List<Blog2Model> GetAllBlogList()
        {
            List<Blog2Model> list = new List<Blog2Model>();

            using (var ct=new Context())
            {
                list = ct.Blogs.Select(x => new Blog2Model
                {
                    ID=x.BlogID,
                    BlogName=x.BlogTitle
                }).ToList();
            }

            return list;


        }
        public IActionResult BlogDynamicListExcel()
        {
            return View();
        }

    }
}

   

