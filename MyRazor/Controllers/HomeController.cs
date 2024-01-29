using Microsoft.AspNetCore.Mvc;
using MyRazor.Models;
using System.Diagnostics;

namespace MyRazor.Controllers
{
    public class HomeController : Controller
    {       
        
        public IActionResult Index()
        {
            ViewData["param1"] = "hello step";
            return View();
        }

        public IActionResult Index2()
        {            
            return Content("1234");
        }

        [HttpPost]
        public ActionResult MyPost(City city)
        {
            return Content(city.Id + " " + city.Name);
        }

    }
}