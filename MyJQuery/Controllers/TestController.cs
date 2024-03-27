using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyJQuery.Model;

namespace MyJQuery.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        List<City> lst;
        public TestController()
        {
            lst = new List<City>()
            {
                new City{Id=1, Name="Астана"},
                new City{Id=2, Name="NY"},
                new City{Id=3, Name="Москва"}
            };
        }

        [HttpGet("SayHello/{name}")]
        public ActionResult SayHello(string name)
        {
            return Ok("Hello " + name);
        }

        [HttpGet("getCityAll")]
        public ActionResult getCityAll()
        {            
            return Ok(lst);
        }

        [HttpPost("createCity")]
        public ActionResult createCity(City city)
        {
            lst.Add(city);
            return Ok("ok");
        }
    }
}
