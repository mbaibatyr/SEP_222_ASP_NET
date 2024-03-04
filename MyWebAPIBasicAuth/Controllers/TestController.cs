using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace MyWebAPIBasicAuth.Controllers
{
    [Route("[controller]")]
    [ApiController]
    [Authorize]

    public class TestController : ControllerBase
    {
        [HttpGet("SayHello")]
        public ActionResult SayHello(string name)
        {
            return Ok($"Hello {name} {User.Identity.Name}  {User.FindFirstValue("psw")}");
        }

        [HttpGet("Download")]
        public ActionResult Download()
        {
            return Ok($"Hello {name} {User.Identity.Name}  {User.FindFirstValue("psw")}");
        }
    }
}
