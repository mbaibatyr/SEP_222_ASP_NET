using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyReact2.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace MyReact2.Controllers
{
    [Route("[controller]")]
    [ApiController]
    [Authorize]
    public class MyController : ControllerBase
    {
        [HttpGet, Route("GetCity")]
        public ActionResult GetCity()
        {
            var model = new List<City>()
            {
                new City() { id = 1, name="Almaty"},
                new City() { id = 2, name="Aktobe"},
                new City() { id = 3, name="Astana"}
            };
            return Ok(model);
        }
    }
}
