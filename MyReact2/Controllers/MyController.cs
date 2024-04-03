using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyReact2.Abstract;
using MyReact2.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Threading;

namespace MyReact2.Controllers
{
    [Route("[controller]")]
    [ApiController]
    [Authorize]
    public class MyController : ControllerBase
    {
        ICity service;
        public MyController(ICity service)
        {
            this.service = service;
        }
        [HttpGet, Route("GetCity")]
        public ActionResult GetCity()
        {
            //Thread.Sleep(3000);
            //var model = new List<City>()
            //{
            //    new City() { id = 1, name="Almaty"},
            //    new City() { id = 2, name="Aktobe"},
            //    new City() { id = 3, name="Astana"}
            //};
            return Ok("");
        }

        [HttpPost, Route("AddOrEdit")]
        public ActionResult AddOrEdit(City request)
        {
            return Ok(service.AddOrEdit(request));
        }

        [HttpGet, Route("GetCityAll/{id}")]
        public ActionResult GetCityAll(string id)
        {
            return Ok(service.GetCityAll(id));
        }
    }
}
