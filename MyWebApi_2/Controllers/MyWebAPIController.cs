using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyWebApi_2.Model;

namespace MyWebApi_2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MyWebAPIController : ControllerBase
    {
        List<Student> lst;

        public MyWebAPIController()
        {
            lst = new List<Student>()
            {
                new Student{Id=1, FirstName="Артем", LastName="Кан", DateBirth=DateTime.Now.AddYears(-20)},
                new Student{Id=2, FirstName="Рустам", LastName="Петров", DateBirth=DateTime.Now.AddYears(-25)},
                new Student{Id=3, FirstName="Канат", LastName="Иванов", DateBirth=DateTime.Now.AddYears(-30)}
            };
        }

        [HttpGet, Route("index/{name}")]
        public ActionResult Index(string name)
        {
            var res = Response;
            return Ok("hello " + name);
        }

        [HttpGet, Route("index2")]
        public ActionResult Index2(string name)
        {
            //var r = Request.Headers["User-Agent"].ToString();
            return Ok("hello " + name);
        }

        [HttpGet, Route("getStudentById/{id}")]
        public ActionResult getStudentById(int id)
        {
            return Ok(lst.Where(z => z.Id == id).FirstOrDefault());
        }

        [HttpGet, Route("getStudentAll")]
        public ActionResult getStudentAll()
        {
            return Ok(lst);
        }

        [HttpGet, Route("getStudentByIdFull/{id}")]
        public ActionResult getStudentByIdFull(int id)
        {
            var result = lst.Where(z => z.Id == id).FirstOrDefault();

            GetStudentByIdFullResponse response = new GetStudentByIdFullResponse
            {
                Status = new ResponseResult
                {
                    Result = result == null ? "no data" : "ok",
                    Status = result != null ? StatusEnum.OK : StatusEnum.ERROR
                },
                Student = result
            };
            return Ok(response);
        }

        [HttpPost, Route("GetStudentViaPost")]
        public ActionResult GetStudentViaPost(GetStudentViaPostRequest request)
        {
            if(string.IsNullOrEmpty(request.id?.ToString()))
                return Ok(lst);
            return Ok(lst.Where(z => z.Id == request.id).FirstOrDefault());
        }
    }
}
