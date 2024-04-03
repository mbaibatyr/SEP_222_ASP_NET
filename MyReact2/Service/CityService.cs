using Dapper;
using MyReact2.Abstract;
using MyReact2.Model;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace MyReact2.Service
{
    public class CityService : ICity
    {
        string conStr = "Server=206-P;Database=testdb;Trusted_Connection=True;";
        public string AddOrEdit(City request)
        {
            using (SqlConnection db = new SqlConnection(conStr))
            {
                DynamicParameters p = new DynamicParameters(request);
                return db.ExecuteScalar<string>("pCity", p, commandType: CommandType.StoredProcedure);
            }
        }

        public IEnumerable<City> GetCityAll(string id)
        {
            using (SqlConnection db = new SqlConnection(conStr))
            {
                return db.Query<City>("pCity;2", new { @id = id }, commandType: CommandType.StoredProcedure);
            }
        }
    }
}
