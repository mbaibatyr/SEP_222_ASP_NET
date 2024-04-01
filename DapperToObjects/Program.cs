using System.Data.SqlClient;
using Newtonsoft.Json;
using Dapper;
using RestSharp;

namespace DapperToObjects
{
    public class Program
    {
        static string conStr = "Server=206-P;Database=testdb;Trusted_Connection=True;";
        static void Main(string[] args)
        {
            //test_1("1");
            //test_2("1");
            //test_3("1");
            //test_4("1");

            var client = new RestClient();
            var request = new RestRequest("http://localhost:5099/test/getCityAll", Method.Get);
            RestResponse response = client.Execute(request);
            Console.WriteLine(response.Content);

        }

        static void test_1(string id)
        {
            using (SqlConnection db = new SqlConnection(conStr))
            {
                string sql = "select id, name from country where id = " + id;
                sql += " select id, name, country_id from city where country_id = " + id;
                var multy = db.QueryMultiple(sql);
                Model.Country country = multy.Read<Model.Country>().FirstOrDefault();
                var citi = multy.Read<Model.City>().ToList();
                country.city = new List<Model.City>();
                foreach (var item in citi)
                {
                    country.city.Add(item);
                }
            }
        }

        static void test_2(string id)
        {
            using (SqlConnection db = new SqlConnection(conStr))
            {
                var sql = "select co.*, city.* from country co join city on co.id = city.country_id where co.id = 1 for json auto, Without_Array_Wrapper";
                var json = db.ExecuteScalar<string>(sql);
                var country = JsonConvert.DeserializeObject<Model.Country>(json);
            }
        }

        static void test_3(string id)
        {
            using (SqlConnection db = new SqlConnection(conStr))
            {
                var sql3 = @"select co.id co_id, co.name co_name, ci.id ci_id, ci.name ci_name, ci.country_id
                from country co join city ci on co.id = ci.country_id
                where co.id = " + id;

                var result = db.Query<dynamic>(sql3);

                var co = (from p in result
                          select new Model.Country
                          {
                              id = p.co_id,
                              name = p.co_name,
                              city = (from z in result
                                      select new Model.City
                                      {
                                          id = p.ci_id,
                                          name = p.ci_name,
                                          country_id = p.country_id
                                      }).ToList()
                          }).FirstOrDefault();
            }
        }

        static void test_4(string id)
        {
            using (SqlConnection db = new SqlConnection(conStr))
            {
                var sql3 = @"select co.id co_id, co.name co_name, ci.id ci_id, ci.name ci_name, ci.country_id
                from country co join city ci on co.id = ci.country_id
                where co.id = " + id;

                var result = db.Query<dynamic>(sql3);

                var json = JsonConvert.SerializeObject(
                 result
                     .Select(z => new
                     {
                         id = z.co_id,
                         name = z.co_name,
                         city = result
                                     .Select(z => new
                                     {
                                         id = z.ci_id,
                                         name = z.ci_name,
                                         country_id = z.country_id
                                     })

                     })
                     .FirstOrDefault()
         );
                var country = JsonConvert.DeserializeObject<Model.Country>(json);
            }
        }

    }
}