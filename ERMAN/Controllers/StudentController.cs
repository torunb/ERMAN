using ERMAN.Dtos;
using ERMAN.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ERMAN.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly ErmanDbContext _dbContext;
        public StudentController(ErmanDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpPost(Name ="StudentAPI")]
        public Student Post(StudentDto student)
        {
            var studentNew = new Student
            {
                StudentEmailAddress = student.StudentEmailAddress,
                StudentName = student.StudentName,
                StudentId = student.StudentId,
                IsRejected = student.IsRejected,
            };

            _dbContext.StudentTable.Add(studentNew);
            _dbContext.SaveChanges();
            return studentNew;
        }

    }
}
