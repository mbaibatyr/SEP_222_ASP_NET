using Microsoft.AspNetCore.Mvc;
using MyMVC.Models;
using System.Diagnostics;

namespace MyMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult GetJson()
        {
            //return Json(new Student { Id=1, Name="qwerty"});
            return Json(null);
        }

        [HttpPost]
        public IActionResult PostJson(Student student)
        {
            return Json(student);
        }

        public IActionResult MyMethod()
        {
            ViewData["param1"] = "hello";
            ViewData["param2"] = "STEP";
            ViewBag.param3 = "Hello world";

            //ViewData["param4"] = new Student
            //{
            //    Id = 1,
            //    Name = "qwerty"
            //};

            //ViewData["param5"] = new List<Student>()
            //{
            //    new Student{Id=1, Name="11111"},
            //    new Student{Id=2, Name="22222"}
            //};

            List<City> model = new List<City>()
            {
                new City{ Id=1, Name="111111"},
                new City{ Id=2, Name="222222"},
                new City{ Id=3, Name="333333"}
            };

            return View(model);
        }

    }
}