using Microsoft.AspNetCore.Mvc;

namespace MyMVC.Controllers
{
    public class StudentController : Controller
    {


        public IActionResult Index()
        {
            return View();
        }
    }
}
