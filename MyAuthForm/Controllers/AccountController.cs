using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyAuthForm.Models;
using System.Security.Claims;

namespace MyAuthForm.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        [HttpGet]
        [AllowAnonymous]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult Login(User user)
        {
            /*
             проверка в БД
             */
            if (true)
            {
                var claims = new[] { new Claim(ClaimTypes.Name, user.Login), new Claim(ClaimTypes.Role, "admin"), new Claim("c1", "text") };
                var identity = new ClaimsIdentity(claims, 
                    CookieAuthenticationDefaults.AuthenticationScheme);
                HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, 
                    new ClaimsPrincipal(identity));
                return Redirect("~/Home/Index");
            }
            else
            {
                ModelState.AddModelError("", "Login failed. Please check Username and/or password");
                return View();
            }
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult Register(User user)
        {
            return View();
        }
    }
}
