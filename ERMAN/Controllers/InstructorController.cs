using ERMAN.Dtos;
using ERMAN.Models;
using ERMAN.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ERMAN.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InstructorController : ControllerBase
    {
        private readonly IGeneralInterface<Instructor, InstructorDto> _instrRepo;
        private readonly StudentRepository _studentRepo;
        public InstructorController(IGeneralInterface<Instructor, InstructorDto> instrRepo, StudentRepository studentRepo)
        {
            _instrRepo = instrRepo;
            _studentRepo = studentRepo;
        }

        [HttpPost(Name = "InstructorPost")]
        public void Post(InstructorDto faq)
        {
            _instrRepo.Add(faq);
        }

        [HttpDelete(Name = "InstructorCourseApproveReject")]
        public void ApproveRejectCourseMapped(int courseMappedId, bool approve)
        {
            if (approve)
            {
                _studentRepo.GetCourseMapped( courseMappedId).ApprovedStatus = ApprovedStatus.InstructorApproved;
            }
            else // reject
            {
                _studentRepo.GetCourseMapped( courseMappedId).ApprovedStatus = ApprovedStatus.Rejected;
            }

        }
        [HttpDelete(Name = "InstructorCoursePendingGet")]
        public List<CourseMapped> GetPendingCourseMapped()
        {
            return _studentRepo.GetAllCourses().Where(courseMapped => courseMapped.ApprovedStatus == ApprovedStatus.CoordinatorApproved).ToList();
        }

        [HttpGet(Name = "InstructorGet")]
        public Instructor Get(int id)
        {
            return _instrRepo.Get(id);
        }

        [HttpDelete(Name = "InstructorDelete")]
        public Instructor Delete(int id)
        {
            return _instrRepo.Remove(id);
        }


        //[HttpPut(Name = "InstructorPut")]
        //public void Put()
        //{
        //    _instrRepo.Update();
        //}
    }
}
