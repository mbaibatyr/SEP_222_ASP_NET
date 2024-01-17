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

        public IActionResult MyMethod()
        {
            ViewData["param1"] = "hello";
            ViewData["param2"] = "STEP";
            ViewBag.param3 = "Hello world";

            ViewData["param4"] = new Student
            {
                Id = 1,
                Name = "qwerty"
            };

            ViewData["param5"] = new List<Student>()
            {
                new Student{Id=1, Name="11111"},
                new Student{Id=2, Name="22222"}
            };

            return View();
        }

    }
}