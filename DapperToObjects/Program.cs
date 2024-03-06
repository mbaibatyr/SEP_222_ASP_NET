using System.Data.SqlClient;
using Dapper;

namespace DapperToObjects
{
    public class Program
    {
        static string conStr = "Server=206-P;Database=testdb;Trusted_Connection=True;";
        static void Main(string[] args)
        {
            test_1("1");
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
    }
}