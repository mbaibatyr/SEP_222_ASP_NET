using Dapper;
using MyMVC.Abstract;
using MyMVC.Models;
using System.Data;
using System.Data.SqlClient;

namespace MyMVC.Service
{
    public class StudentService : IStudent
    {
        readonly string conStr = "Server=206-P;Database=testdb;Trusted_Connection=True;";
        public IEnumerable<Student> getStudentAll()
        {
            using (SqlConnection db = new SqlConnection(conStr))
            {
                return db.Query<Student>("pStudent", commandType: CommandType.StoredProcedure);
            }
        }

        public Student getStudentById(string id)
        {
            using (SqlConnection db = new SqlConnection(conStr))
            {
                return db.Query<Student>("pStudent;2", new { id = id }, commandType: CommandType.StoredProcedure).FirstOrDefault();
            }
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