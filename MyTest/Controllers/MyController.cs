using Microsoft.AspNetCore.Mvc;
using MyTest.Models;
using System.Data.SqlClient;
using Dapper;
using System.Data;

namespace MyTest.Controllers
{
    public class MyController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            //ViewData["key1"] = "hello";
            //ViewData["key2"] = "STEP";

            //ViewData["key3"] = new Book
            //{
            //    Id = 1,
            //    Title="Война и мир",
            //    Cost = 1000
            //};

            //var model = new List<Book>()
            //{
            //    new Book{Id = 1,Title = "Война и мир", Cost = 1000 },
            //    new Book{Id = 2,Title = "Евгений Онегин", Cost = 2000 }
            //};

            //ViewData["key4"] = model;

            //using (SqlConnection db = new SqlConnection(""))
            {
                //var book = db.Query<Book>("select id, title, cost from book where id = 1").FirstOrDefault();
                //return View(book);
                return View(new Book
                {
                    Id = 10,
                    Title = "Война и мир 2",
                    Cost = 10000
                });
            }
        }

        [HttpPost]
        public ActionResult Index(Book model)
        {
            //using (SqlConnection db = new SqlConnection(""))
            {
                //DynamicParameters p = new DynamicParameters(model);
                //var result = db.ExecuteScalar<string>("pBook", p, commandType: CommandType.StoredProcedure);
                var result = "exists";
                if (result == "exists")
                {
                    ModelState.AddModelError("", "This book already exists");
                    return View();
                }
                return Redirect("");
            }
        }
    }
}
