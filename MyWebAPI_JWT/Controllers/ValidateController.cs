using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MyWebAPI_JWT.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValidateController : ControllerBase
    {
        IConfiguration config;
        public ValidateController(IConfiguration config)
        {
            this.config = config;
        }
        [AllowAnonymous]
        [HttpPost, Route("GetToken")]
        public ActionResult GetToken(UserModel model)
        {

        }
    }
}
