using Dapper;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MyAuthForm.Models;
using System.Data;
using System.Data.SqlClient;
using System.Security.Claims;

namespace MyAuthForm.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        IConfiguration config;
        public AccountController(IConfiguration config)
        {
            this.config = config;
        }

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
            using (SqlConnection db = new SqlConnection(config["conStr"]))
            {
                var result = db.Query<dynamic>("pUsers;2", new { login = user.Login, pwd = user.Password }, commandType: CommandType.StoredProcedure).FirstOrDefault();
                if (result == null)
                {
                    ModelState.AddModelError("", "Login failed. Please check Username and/or password");
                    return View();
                }

                int id = result.id;
                string login = result.login;
                string role_name = result.role_name;
                var claims = new[] { new Claim(ClaimTypes.Name, user.Login),
                    new Claim(ClaimTypes.Role, role_name),
                    new Claim("id", id.ToString())
                };
                var identity = new ClaimsIdentity(claims,
                    CookieAuthenticationDefaults.AuthenticationScheme);
                HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                    new ClaimsPrincipal(identity));
                return Redirect("~/Home/Index");

            }
            if (true)
            {
                var claims = new[] { new Claim(ClaimTypes.Name, user.Login),
                    new Claim(ClaimTypes.Role, "admin"),
                    new Claim("c1", "text")
                };
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



        [HttpGet]
        [AllowAnonymous]
        public ActionResult Register()
        {
            using (SqlConnection db = new SqlConnection(config["conStr"]))
            {
                //var result = db.Query<Roles>("pUsers;3", commandType: CommandType.StoredProcedure);
                var result = new List<Roles>()
                {
                    new Roles{id="1", name="admin"},
                    new Roles{id="2", name="sale"},
                    new Roles{id="3", name="market"},
                };

                ViewBag.role = new SelectList(result, "id", "name", "3");
                return View();
            }

        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult Register(User user)
        {
            using (SqlConnection db = new SqlConnection(config["conStr"]))
            {
                DynamicParameters p = new DynamicParameters(user);
                var result = db.Query<Roles>("pUsers", p, commandType: CommandType.StoredProcedure);
                return Redirect("~/Home/Index");
            }

            return View();
        }
    }
}
