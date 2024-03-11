using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using MyWebAPI_JWT.Model;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

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
            try
            {


                /*
                 проверка в БД
                 */

                //return Unauthorized(new ReturnStatus
                //{
                //    status = StatusEnum.ERROR,
                //    result = "error"
                //});

                var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["Jwt:Key"]));
                var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha512);

                var claims = new[] {
                      new Claim("myRole", "admin"),
                      new Claim("dateBirth", "2000-01-01")
            };

                var token = new JwtSecurityToken(config["Jwt:Issuer"],
                    config["Jwt:Issuer"],
                    claims,
                    //null,
                    expires: DateTime.Now.AddMinutes(5),
                    signingCredentials: credentials);

                var sToken = new JwtSecurityTokenHandler().WriteToken(token);

                return Ok(new ReturnStatus
                {
                    status = StatusEnum.OK,
                    result = sToken
                });
            }
            catch (Exception err)
            {
                return Ok(new ReturnStatus
                {
                    status = StatusEnum.ERROR,
                    result = "error",
                    error = err.Message
                });
            }
        }

        [HttpGet, Authorize, Route("GetTest/{name}")]
        public ActionResult GetTest(string name)
        {
            return Ok("Hello " + name + " " + User.FindFirst("myRole")?.Value);
        }




        
        //[HttpGet, Route("GetRefreshToken")]
        //public ActionResult GetRefreshToken()
        //{
        //    var secureRandomBytes = new byte[32];

        //    using var randomNumberGenerator = RandomNumberGenerator.Create();
        //    randomNumberGenerator.GetBytes(secureRandomBytes);
        //    var refreshToken = Convert.ToBase64String(secureRandomBytes);
        //    return Ok(refreshToken);
        //}
    }
}
