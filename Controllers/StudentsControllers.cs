using Microsoft.AspNetCore.Mvc;
using Sheenam.Data;
using Sheenam.Models;

namespace Sheenam.Controllers
{
    [ApiController]
    [Route("api/students")]
    public class StudentsControllers : ControllerBase
    {
        AppDbContext dbContext = new AppDbContext();

        [HttpPost]
        public bool CreateStudent(Student student)
        {
             dbContext.students.Add(student);
            dbContext.SaveChanges();
            return true;
        }

        [HttpGet] // apt/students
        public List<Student> GetAllStudents()
        {
            return dbContext.students.ToList();
        }

        [HttpGet("{id}")] // api/students/id
        public Student GetByIdStudent(int id)
        {
            var myStudent = dbContext.students.FirstOrDefault(x => x.Id == id);
            return myStudent;
        }

        [HttpPut]
        public bool UpdateStudent(Student student)
        {
            var myStudent = dbContext.students.FirstOrDefault(x=>x.Id == student.Id);

            if(myStudent is null)
            {
                return false;
            }
            myStudent.FirstName = student.FirstName;
            myStudent.LastName = student.LastName;
            myStudent.Age = student.Age;
            dbContext.SaveChanges();
            return true;
        }

        [HttpDelete("{id}")]
        public bool DeleteStudent(int id)
        {
            var myStudent = dbContext.students.FirstOrDefault(x=>x.Id==id);

            if(myStudent is null)
            {
                return false;
            }

            dbContext.students.Remove(myStudent);
            dbContext.SaveChanges();
            return true;
        }
    }
}
