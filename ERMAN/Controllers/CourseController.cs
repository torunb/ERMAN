using ERMAN.Dtos;
using ERMAN.Models;
using ERMAN.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ERMAN.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private readonly IGeneralInterface<Course, CourseDto> _courseRepo;
        public CourseController(IGeneralInterface<Course, CourseDto> courseRepo)
        {
            _courseRepo = courseRepo;
        }

        [HttpPost(Name = "CoursePost")]
        public void Post(CourseDto course)
        {
            _courseRepo.Add(course);
        }


        [HttpGet(Name = "CourseGet")]
        public Course Get(int id)
        {
            return _courseRepo.Get(id);
        }

        [HttpDelete(Name = "CourseDelete")]
        public Course Delete(int id)
        {
            return _courseRepo.Remove(id);
        }

        [HttpPut(Name = "CoursePut")]
        public void Put()
        {
            //_courseRepo.Update();
        }
    }
}
