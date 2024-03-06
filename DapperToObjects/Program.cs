using System.Data.SqlClient;
using Newtonsoft.Json;
using Dapper;

namespace DapperToObjects
{
    public class Program
    {
        static string conStr = "Server=206-P;Database=testdb;Trusted_Connection=True;";
        static void Main(string[] args)
        {
            //test_1("1");
            test_2("1");
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

    }
}