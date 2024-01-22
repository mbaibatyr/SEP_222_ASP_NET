using Microsoft.AspNetCore.Mvc;
using MyMVC.Models;

namespace MyMVC.Controllers
{
    [Route("admin")]
    public class MyController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            ViewData["message"] = "Hello STEP";
            return View();
        }

        [HttpGet, Route("getindex1/{name1}/{name2}")]
        public ActionResult ContentIndex(string name1, string name2)
        {
            return Content("hello " + name1 + " !!!!!!! " + name2);
        }

        [HttpGet, Route("JsonIndex/{id}")]
        public ActionResult JsonIndex(int id)
        {
            List<City> model = new List<City>()
            {
                new City{ Id=1, Name="111111"},
                new City{ Id=2, Name="222222"},
                new City{ Id=3, Name="333333"}
            };
            return Json(model.Where(z => z.Id == id).FirstOrDefault());
        }

        [HttpGet, Route("RedirectIndex")]
        public ActionResult RedirectIndex()
        {
            return RedirectToAction("Index", "Home");
        }

        [HttpGet, Route("StatusCodeIndex")]
        public ActionResult StatusCodeIndex()
        {
            /*
             проверка есть ли аккаунт в БД
             */
            return StatusCode(404);
        }


        [HttpGet, Route("FileIndex")]
        public ActionResult FileIndex()
        {            
            var path = @"C:\Temp\1.jpg";
            FileInfo info = new FileInfo(path);
            var res = info.Exists;


             
            return File(path, "image/jpeg");

            //string name = "me.txt";

            //FileInfo info = new FileInfo(name);
            //if (!info.Exists)
            //{
            //    using (StreamWriter writer = info.CreateText())
            //    {
            //        writer.WriteLine("Hello, I am a new text file");

            //    }
            //}

            //return File(info.OpenRead(), "text/plain");
        }


        [HttpPost, Route("PostIndex")]
        public ActionResult PostIndex(City model)
        {
            return Json(model);
        }

        [HttpDelete, Route("DeleteIndex/{id}")]
        public ActionResult DeleteIndex(string id)
        {
            return Content(id);
        }
    }
}
