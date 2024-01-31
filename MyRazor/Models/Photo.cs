namespace MyRazor.Models
{
    public class Photo
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Extension { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public DateTime DateCreated { get; set; }
    }

    public class Status
    {
        public StatusEnum status { get; set; }
        public string result { get; set; }
        public string error { get; set; }
    }

    public enum StatusEnum
    {
        OK = 1,
        ERROR = 0,
        CRITICAL_ERROR = -1
    }
}
