using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MyJQuery.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        [HttpGet("SayHello/{name}")]
        public ActionResult SayHello(string name)
        {
            return Ok("Hello " + name);
        }
    }
}
