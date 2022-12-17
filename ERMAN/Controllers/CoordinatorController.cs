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
    public class CoordinatorController : ControllerBase
    {
        private readonly CoordinatorRepository repository;
        private readonly StudentRepository _studentRepo;

        public CoordinatorController(CoordinatorRepository repository, StudentRepository studentRepository)
        {
            this.repository = repository;
            _studentRepo = studentRepository;
        }

        [HttpDelete(Name = "CoordinatorCourseApproveReject")]
        public void ApproveRejectCourseMapped(int courseMappedId, bool approve)
        {
            if (approve)
            {
                CourseMapped mapped = _studentRepo.GetCourseMapped(courseMappedId);
                if ( mapped.BilkentCourse.IsMustCourse)
                {
                    mapped.ApprovedStatus = ApprovedStatus.CoordinatorApproved;
                }
                else // it is an approved elective course
                {
                    mapped.ApprovedStatus = ApprovedStatus.InstructorApproved;
                }
            }
            else // reject
            {
                _studentRepo.GetCourseMapped(courseMappedId).ApprovedStatus = ApprovedStatus.Rejected;
            }

        }

        [HttpDelete(Name = "CoordinatorCoursePendingGet")]
        public List<CourseMapped> GetPendingCourseMapped()
        {
            return _studentRepo.GetAllCourses().Where(courseMapped => courseMapped.ApprovedStatus == ApprovedStatus.Pending).ToList();
        }


    }
}
