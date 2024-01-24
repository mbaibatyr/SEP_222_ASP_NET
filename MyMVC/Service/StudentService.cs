using MyMVC.Abstract;
using MyMVC.Models;

namespace MyMVC.Service
{
    public class StudentService : IStudent
    {
        public IEnumerable<Student> getStudentAll()
        {
            throw new NotImplementedException();
        }

        public Student getStudentById(string id)
        {
            throw new NotImplementedException();
        }

        public Result StudentAdd(Student model)
        {
            throw new NotImplementedException();
        }
    }
}

/*
 CREATE table Student
(
	id int primary key identity,
	lastName nvarchar(200),
	firstName nvarchar(200),
	birthDate datetime
)

alter proc pStudent --getStudentAll
as
select 
	id,
	lastName,
	firstName,
	birthDate
from Student
order by lastName

alter proc pStudent;2 --getStudentById
@id int
as
select 
	id,
	lastName,
	firstName,
	birthDate
from Student
where id= @id
 
 */