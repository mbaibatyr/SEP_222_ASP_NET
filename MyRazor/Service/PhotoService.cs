using Dapper;
using MyRazor.Abstract;
using MyRazor.Models;
using System.Data;
using System.Data.SqlClient;

namespace MyRazor.Service
{
    public class PhotoService : IPhoto<Photo>
    {
        IConfiguration config;
        public PhotoService(IConfiguration config)
        {
            this.config = config;
        }
        public Status AddOrEditPhoto(Photo model)
        {
            using (SqlConnection db = new SqlConnection(config["conStr"]))
            {
                DynamicParameters p = new DynamicParameters(model);
                p.Add("returnValue", null, DbType.Int32, ParameterDirection.ReturnValue);
                db.Execute("pPhoto;2", p, commandType: CommandType.StoredProcedure);
                var result = p.Get<int>("@returnValue");
                if (result == 1)
                    return new Status
                    {
                        status = StatusEnum.OK,
                        result = "ok"
                    };
                return new Status
                {
                    status = StatusEnum.ERROR,
                    result = "error"
                };
            }
        }

        public IEnumerable<Photo> GetPhotoAllorById(string id)
        {
            using (SqlConnection db = new SqlConnection(config["conStr"]))
            {
                return db.Query<Photo>("pPhoto", new { id = id }, commandType: CommandType.StoredProcedure);
            }
        }

        public Photo GetPhotoById(string id)
        {
            using (SqlConnection db = new SqlConnection(config["conStr"]))
            {
                return db.Query<Photo>("pPhoto", new { id = id }, commandType: CommandType.StoredProcedure).FirstOrDefault();
            }
        }
    }
}
