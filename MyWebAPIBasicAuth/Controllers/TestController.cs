using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;
using System.Security.Claims;

namespace MyWebAPIBasicAuth.Controllers
{
    [Route("[controller]")]
    [ApiController]
    //[Authorize]

    
    public class TestController : ControllerBase
    {
        [HttpGet("SayHello")]
        //[DisableCors()]
        public ActionResult SayHello(string name)
        {
            //string st = null;
            //Request.Headers.TryGetValue("name123", out StringValues headerValue);
            
            return Ok($"Hello {name} {User.Identity.Name}  {User.FindFirstValue("psw")}");
        }


        [HttpGet("set_cookie/{key}/{value}"), AllowAnonymous]
        public ActionResult set_cookie(string key, string value)
        {            
            Response.Cookies.Append(key, value, new CookieOptions()
            {
                Expires = DateTimeOffset.Now.AddDays(12),
                HttpOnly = true,
                Secure = true                
            });
            return Ok("ok");
        }

        [HttpGet("get_cookie/{key}"), AllowAnonymous]
        public ActionResult get_cookie(string key)
        {
            var value = Request.Cookies[key];
            return Ok(value);
        }


        //[HttpGet("Download")]

        //public ActionResult Download()
        //{
        //    return Ok($"Hello {name} {User.Identity.Name}  {User.FindFirstValue("psw")}");
        //}
    }
}
