using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace MyRazor.Models
{
    public class Photo
    {
        public int Id { get; set; }
        //[Required(ErrorMessage ="Поле Name обязательно для заполнения")]
        //[MaxLength(10, ErrorMessage = "Максимальная длина 10 символов")]
        //[MinLength(0)]
        //[Remote(action: "MyCheck", controller: "Photo", ErrorMessage = "Данные не верные")]
        
        public string Name { get; set; }
        //[EmailAddress(ErrorMessage = "Некорректный адрес")]
        
        public string Extension { get; set; }
        [Range(1, 110, ErrorMessage = "Недопустимый возраст")]
        public int Width { get; set; }
        [Compare("Width", ErrorMessage = "Width и Height не совпадают")]
        public int Height { get; set; }
        [DataType(DataType.Date)]
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
