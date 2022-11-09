using ERMAN.Dtos;
using ERMAN.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ERMAN.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        [HttpPost(Name ="StudentAPI")]
        public Student Post(StudentDto student)
        {
            var studentNew = new Student
            {
                StudentId = student.StudentId,
                StudentEmailAddress = student.StudentEmailAddress,
                StudentName = student.StudentName,
            };
            return studentNew;
        }

    }
}
