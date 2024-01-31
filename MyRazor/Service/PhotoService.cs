using MyRazor.Abstract;
using MyRazor.Models;

namespace MyRazor.Service
{
    public class PhotoService : IPhoto<Photo>
    {
        public Status AddOrEditPhoto(Photo model)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Photo> GetPhotoAllorById(string id)
        {
            throw new NotImplementedException();
        }

        public Photo GetPhotoById(string id)
        {
            throw new NotImplementedException();
        }
    }
}
