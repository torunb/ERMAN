using ERMAN.Dtos;
using ERMAN.Models;
using ERMAN.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ERMAN.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IGeneralInterface<Student, StudentDto> _studentRepo;
        public StudentController(IGeneralInterface<Student, StudentDto> studentRepo)
        {
            _studentRepo = studentRepo;
        }

        [HttpPost(Name = "StudentPost")]
        public void Post(StudentDto faq)
        {
            _studentRepo.Add(faq);
        }

        [HttpGet(Name = "StudentGet")]
        public Student Get(int id)
        {
            return _studentRepo.Get(id);
        }

        [HttpDelete(Name = "StudentDelete")]
        public Student Delete(int id)
        {
            return _studentRepo.Remove(id);
        }

        [HttpPut(Name = "StudentPut")]
        public void Put()
        {
            _studentRepo.Update();
        }

    }
}
