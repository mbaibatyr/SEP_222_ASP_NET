namespace MyMVC.Models
{
    public class Student
    {
        public int id { get; set; }
        public string lastName { get; set; }
        public string firstName { get; set; }
        public DateTime birthDate { get; set; }
    }

    public class City
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class Result
    {
        public string result { get; set; }
        public string error { get; set; }
        public object model { get; set; }
        public StatusEnum status { get; set; }
    }

    public enum StatusEnum
    {
        OK = 1,
        ERROR = 0,
        CriticalError = 2
    }

}
