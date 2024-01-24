using ClosedXML.Excel;
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

            string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "images/1.png");
            FileStream fs = new FileStream(path, FileMode.Open);
            string file_type = "image/jpeg";
            string file_name = "10000.png";
            return File(fs, file_type, file_name);

           



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

        [HttpPut, Route("PutIndex/{param1}")]
        public ActionResult PutIndex(string param1, Student model)
        {
            //return Content($"{param1} - {model.Id} - {model.Name}");
            return Content("");
        }

        [HttpGet, Route("GetExcel")]
        public ActionResult GetExcel()
        {
            using (var ms = new MemoryStream())
            {
                using (XLWorkbook wb = new XLWorkbook())
                {
                    var ws = wb.AddWorksheet("report");
                    ws.Cell(1, 1).Value = "Id";
                    ws.Cell(1, 1).Style.Font.Bold = true;
                    ws.Cell(1, 1).Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);

                    ws.Cell(1, 2).Value = "Name";
                    ws.Cell(1, 2).Style.Font.Bold = true;
                    ws.Cell(1, 2).Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);

                    //ws.Column(1).Width = 25;
                    //ws.Column(2).Width = 15;

                    //List<Student> lst = new List<Student>()
                    //{
                    //    new Student{Id=1, Name="Иванов" },
                    //    new Student{Id=2, Name="Петров" }
                    //};

                    //ws.Cell(2, 1).InsertData(lst);
                    //ws.Cell(2, 1).InsertData(null);
                    ws.RangeUsed().SetAutoFilter();
                    ws.Columns("A", "B").AdjustToContents();

                    ws.SheetView.FreezeRows(1);
                    wb.SaveAs(ms);
                    ms.Position = 0;
                    ms.Flush();
                    var bytes = ms.ToArray();

                    return File(bytes,
                    "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
                    "report____" + DateTime.Now.ToString("ddMMyyyy_hhmmss") + ".xlsx");
                }
            }
        }


       
    }
}
