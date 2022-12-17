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

        [HttpPost(Name = "CourseManagerPost")]
        public void Post(CourseMappedDto courseMapped)
        {
            _courseMappedRepo.Add(courseMapped);
        }

        [HttpGet("/api/CourseManager", Name = "CourseManagerGet")]
        public CourseMapped Get(int id)
        {
            return _courseMappedRepo.Get(id);
        }
        [HttpGet("/api/CourseManager/All",Name = "CourseManagerGetAll")]
        public IEnumerable<CourseMapped> GetAll()
        {
            return _courseMappedRepo.GetAll();
        }

        [HttpGet("/api/CourseManager/Approved", Name = "CourseManagerGetApproved")]
        public IEnumerable<CourseMapped> GetApproved()
        {
            
            return _courseMappedRepo.GetApproved();
        }

        /*
        [HttpGet("/api/CourseManager/Selected", Name = "CourseManagerGetSelected")]
        public IEnumerable<CourseMapped> GetSelected()
        {
            var authId = (int)HttpContext.Items["userID"];
            return _courseMappedRepo.GetSelected(authId);
        }*/

        [HttpGet("/api/CourseManager/Rejected", Name = "CourseManagerGetRejected")]
        public IEnumerable<CourseMapped> GetRejected(int id)
        {
            return _courseMappedRepo.GetRejected();
        }

        [HttpDelete(Name = "CourseManagerDelete")]
        public void Delete(int id)
        {
            _courseMappedRepo.Remove(id);
        }

        [HttpPut(Name = "CourseManagerPut")]
        public void Put()
        {
            //_courseRepo.Update();
        }
    }
}
