using Microsoft.AspNetCore.Mvc;
using MyWindowsAuth.Models;
using System.Diagnostics;
using Microsoft.AspNetCore.Authorization;

namespace MyWindowsAuth.Controllers
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
            var username = User.Identity.Name.Split('\\')[1];
            return View();
            //using (SqlConnection db = new SqlConnection())
            //{
            //    var result = db.ExecuteScalar<string>("select '1' from users2 where user = '" + username + "'");
            //    if(result == null)
            //        return RedirectToAction("GetError");
            //    return View();

            //    var result2 = db.ExecuteScalar<int>("select count(1) from users2 where user = '" + username + "'");
            //    if (result2 > 0)
            //        return View(); 
            //    return RedirectToAction("GetError");
            //}

        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult GetError()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}