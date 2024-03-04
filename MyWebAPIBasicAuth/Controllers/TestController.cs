using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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
            return Ok($"Hello {name}");
        }
    }
}
