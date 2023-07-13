using CoreDemo.Areas.Admin.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;

namespace CoreDemo.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class WriterController : Controller
    {


        public static List<WriterModel> list = new List<WriterModel>()
        {
            new WriterModel()
            {
                Id = 1,
                Name="Ebrar"

            },
            new WriterModel()
            {
                Id=2,
                Name="Betül"
            },
            new WriterModel(){
                Id=3,
                Name="Ali"
            }

        };


        public IActionResult Index()
        {


            return View();
        }
        public IActionResult WriterList()
        {
            var jsonwriter = JsonConvert.SerializeObject(list);

            return Json(jsonwriter);
        }
        public IActionResult WriterGetByID(int writerid)
        {
            var writer = list.FirstOrDefault(x => x.Id == writerid);

            var jsonWriter = JsonConvert.SerializeObject(writer);
            return Json(jsonWriter);

        }

        [HttpPost]

        public IActionResult WriterAdd(WriterModel writerModel)
        {
            list.Add(writerModel);
            var js = JsonConvert.SerializeObject(writerModel);
            return Json(js);

        }
        [HttpPost]

        public IActionResult WriterDelete(int id)
        {
            var writer = list.FirstOrDefault(z => z.Id == id);
            list.Remove(writer);
            return Json(writer);

        }
        [HttpPost]

        public IActionResult WriterUpdate(WriterModel writer)
        {
            
            var bul=list.FirstOrDefault(x => x.Id == writer.Id);
            bul.Name = writer.Name;
            var js = JsonConvert.SerializeObject(writer);

            return Json(writer);

        }
    }
}
