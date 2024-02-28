using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyWebApi_2.Model;

namespace MyWebApi_2.Controllers
{
    [Route("stepapi/[controller]")]
    [ApiController]
    public class Test2Controller : ControllerBase
    {
        List<Student> lst;
        public Test2Controller()
        {
            lst = new List<Student>()
            {
                new Student{Id=1, FirstName="Артем", LastName="Кан", DateBirth=DateTime.Now.AddYears(-20)},
                new Student{Id=2, FirstName="Рустам", LastName="Петров", DateBirth=DateTime.Now.AddYears(-25)},
                new Student{Id=3, FirstName="Канат", LastName="Иванов", DateBirth=DateTime.Now.AddYears(-30)}
            };
        }
        [HttpPost("Post_1")]
        public ActionResult Post_1(List<Student> lst)
        {
            return Ok(lst.Count());            
        }

        [HttpPost("Post_2")]
        public ActionResult Post_2([FromQuery] QueryById request)
        {
            var result = lst.Where(z => z.Id == int.Parse(request.id));
            return Ok(result);
        }

        [HttpPost("Post_3")]
        public ActionResult Post_3([FromBody] string id)
        {
            //var result = lst.Where(z => z.Id == int.Parse(id));
            var result = lst.Where(z => z.LastName.Contains(id));
            return Ok(result);
        }

        [HttpPost("Post_4")]
        public ActionResult Post_4(string[] array)
        {
            return Ok(array.Length);
        }

        [HttpGet("Get_1")]
        public ActionResult Get_1([FromQuery] QueryById request)
        {
            if (string.IsNullOrEmpty(request.id))
                return Ok(lst);
            return Ok(lst.Where(z => z.Id == int.Parse(request.id)).FirstOrDefault());
        }

        [HttpPost("Put_1/{id}")]
        public ActionResult Put_1(string id, Student request)
        {
            lst.Add(request);
            return Ok(lst.Where(z=>z.Id == int.Parse(id)));
        }

        [HttpPost("Post_5")]
        public ActionResult Post_5([FromHeader(Name = "MyHeader")] string agent)
        {
            return Ok(agent);
        }

        [HttpPost("Post_6/{var1}")]
        public ActionResult Post_6([FromRoute] string var1)
        {
            return Ok(var1);
        }

        [HttpPost("uploadFile")]
        public ActionResult uploadFile(IFormFile file)
        {
            if (!file.FileName.EndsWith(".txt"))
                return Ok("not txt");
            MemoryStream ms = new MemoryStream();
            file.CopyTo(ms);
            ms.Position = 0;            
            return Ok(System.Text.Encoding.UTF8.GetString(ms.ToArray()));
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
