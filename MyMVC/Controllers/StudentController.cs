using Microsoft.AspNetCore.Mvc;
using MyMVC.Abstract;
using MyMVC.Service;

namespace MyMVC.Controllers
{
    public class StudentController : Controller
    {
        IStudent service;
        public StudentController(/*IStudent service*/)
        {
            this.service = new StudentService();
        }

        [HttpGet, Route("getStudentAll")]
        public ActionResult getStudentAll()        
        {
            return Ok(service.getStudentAll());
        }

        [HttpGet, Route("getStudentById/{id}")]
        public ActionResult getStudentById(string id)
        {
            return Ok(service.getStudentById(id));
        }
    }
}
