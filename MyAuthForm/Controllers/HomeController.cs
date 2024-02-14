using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyAuthForm.Models;
using System.Diagnostics;
using System.Security.Claims;

namespace MyAuthForm.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            ViewData["role"] = User.FindFirstValue(ClaimTypes.Role);
            ViewBag.id = User.FindFirstValue("id");
            return View();
        }

        public IActionResult Privacy()
        {
            if (User.FindFirstValue(ClaimTypes.Role) != "admin")
                return Redirect("~/Home/Error/UnAuthorized");
            return View();
        }

       

        public ActionResult Error(string id)
        {
            ViewData["textError"] = id;
            return View();
        }
    }
}