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
            throw new NotImplementedException();
        }

        public IEnumerable<Photo> GetPhotoAllorById(string id)
        {
            using (SqlConnection db = new SqlConnection(config["conStr"]))
            {
                return db.Query<Photo>("pPhoto", new { id = id }, commandType:CommandType.StoredProcedure);
            }
        }

        public Photo GetPhotoById(string id)
        {
            throw new NotImplementedException();
        }
    }
}
