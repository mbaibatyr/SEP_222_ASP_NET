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
}
