using MyMVC.Models;

namespace MyMVC.Abstract
{
    public interface IStudent
    {
        IEnumerable<Student> getStudentAll();
        Student getStudentById(string id);
        Result StudentAdd(Student model);
    }
}
