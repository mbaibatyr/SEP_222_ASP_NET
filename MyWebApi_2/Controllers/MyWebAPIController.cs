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
            if (string.IsNullOrEmpty(request.id?.ToString()))
                return Ok(lst);
            return Ok(lst.Where(z => z.Id == request.id).FirstOrDefault());
        }

        [HttpPost, Route("GetStudentViaPost2")]
        public ActionResult GetStudentViaPost2([FromQuery] GetStudentViaPostRequest request)
        {
            if (string.IsNullOrEmpty(request.id?.ToString()))
                return Ok(lst);
            return Ok(lst.Where(z => z.Id == request.id).FirstOrDefault());
        }

        [HttpPost, Route("GetStudentViaPost3/{id}")]
        public ActionResult GetStudentViaPost3(string id, [FromQuery] GetStudentViaPostRequest2 request)
        {
            if (string.IsNullOrEmpty(request.FirstName) || string.IsNullOrEmpty(request.LastName))
                return Ok(lst);
            return Ok(lst.Where(z => z.LastName == request.LastName && z.FirstName == request.FirstName).FirstOrDefault());
        }

        [HttpPost, Route("GetStudentViaPost4")]
        public ActionResult GetStudentViaPost4([FromBody] (string LastName, string FirstName) parameters)
        {
            if (string.IsNullOrEmpty(parameters.LastName))
                return Ok(lst);
            return Ok(lst.Where(z => z.LastName == parameters.LastName).FirstOrDefault());
        }
        [HttpPost, Route("GetStudentViaPost5/{LastName}/{FirstName}")]
        public ActionResult GetStudentViaPost5([FromRoute] GetStudentViaPostRequest2 request)
        {
            if (string.IsNullOrEmpty(request.LastName))
                return Ok(lst);
            return Ok(lst.Where(z => z.LastName == request.LastName).FirstOrDefault());
        }

        [HttpPost, Route("GetStudentViaPost6")]
        public ActionResult GetStudentViaPost6([FromForm] GetStudentViaPostRequest2 request)
        {
            if (string.IsNullOrEmpty(request.LastName))
                return Ok(lst);
            return Ok(lst.Where(z => z.LastName == request.LastName).FirstOrDefault());
        }

        [HttpPost, Route("GetStudentViaPost7")]
        public ActionResult GetStudentViaPost7([FromHeader(Name = "User-Agent")] string Agent)
        {
            return Ok(Agent);
        }

        [HttpGet, Route("GetStudentViaPost8")]
        public ActionResult GetStudentViaPost8([FromQuery] GetStudentViaPostRequest2 request)
        {
            if (string.IsNullOrEmpty(request.LastName))
                return Ok(lst);
            return Ok(lst.Where(z => z.LastName == request.LastName).FirstOrDefault());
        }

        [HttpPost, Route("GetStudentViaPost9")]
        public ActionResult GetStudentViaPost9(string[] array)
        {
            return Ok(string.Join(';', array));
        }

        [HttpPost, Route("GetStudentViaPost10")]
        public ActionResult GetStudentViaPost10(List<GetStudentViaPostRequest2> lst)
        {
            return Ok(lst.Count());
        }

        [HttpPost("uploadFile")]
        public ActionResult uploadFile(IFormFile file)
        {
            return Ok(file.Length);
        }

        [HttpPost("downloadFile")]
        public ActionResult downloadFile(IFormFile file)
        {
            MemoryStream ms = new MemoryStream();
            file.CopyTo(ms);
            ms.Position = 0;
            return File(ms,
                  "application/png",
                  "Sample.png");
        }
    }
}
