using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MyWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MyWebApiController : ControllerBase
    {
      
        [Route("index/{name}/{asdasd}/{asdda}")]
        public ActionResult Index(string name)
        {
            var res = Response;
            return Ok("hello " + name);
        }

        [Route("index2")]
        public ActionResult Index2(string name)
        {
            //var req = Request;
            //var res = Response;
            var r = Request.Headers["User-Agent"].ToString();
            return Ok("hello " + name);
        }

        [Route("getStudentById/{id}")]
        public ActionResult getStudentById(string id)
        {

            return Ok("hello " + name);
        }

    }
}
