using ERMAN.Dtos;
using ERMAN.Models;
using ERMAN.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ERMAN.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseManagerController : ControllerBase
    {
        private readonly CourseMappedRepository _courseMappedRepo;
        public CourseManagerController(CourseMappedRepository courseMappeRepo)
        {
            _courseMappedRepo = courseMappeRepo;
        }

        [HttpPost(Name = "CoursePost")]
        public void Post(CourseMappedDto courseMapped)
        {
            _courseMappedRepo.Add(courseMapped);
        }

        [HttpGet(Name = "CourseGet")]
        public CourseMapped Get(int id)
        {
            return _courseMappedRepo.Get(id);
        }
        [HttpGet(Name = "CourseGetAll")]
        public IEnumerable<CourseMapped> GetAll()
        {
            return _courseMappedRepo.GetAll();
        }

        [HttpGet(Name = "CourseGetApproved")]
        public IEnumerable<CourseMapped> GetApproved()
        {
            return _courseMappedRepo.GetApproved();
        }
        [HttpGet(Name = "CourseGetRejected")]
        public IEnumerable<CourseMapped> GetRejected(int id)
        {
            return _courseMappedRepo.GetRejected();
        }

        [HttpDelete(Name = "CourseDelete")]
        public void Delete(int id)
        {
            _courseMappedRepo.Remove(id);
        }

        [HttpPut(Name = "CoursePut")]
        public void Put()
        {
            //_courseRepo.Update();
        }
    }
}
