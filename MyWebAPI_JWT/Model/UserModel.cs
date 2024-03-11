namespace MyWebAPI_JWT.Model
{
    public class UserModel
    {
        public string login { get; set; }
        public string password { get; set; }
    }

    public class ReturnStatus
    {
        public string result { get; set; }
        public string error { get; set; }
        public StatusEnum status { get; set; }
    }

    public enum StatusEnum
    {
        OK = 1,
        ERROR = 0
    }
}
