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
        private readonly StudentRepository _studentRepo;
        private readonly CourseProposalRepository _proposalRepo;

        public CoordinatorController(StudentRepository studentRepository, CourseProposalRepository proposalRepo)
        {
            _studentRepo = studentRepository;
            _proposalRepo = proposalRepo;
        }

        //[HttpDelete("api/Coordinator/ApproveOrReject", Name = "CoordinatorCourseApproveReject")]
        //public void ApproveRejectCourseMapped(int authId, int courseMappedId, bool approve)
        //{
        //    if (approve)
        //    {
        //        CourseMapped mapped = _studentRepo.GetCourseMapped(courseMappedId);
        //        if ( mapped.BilkentCourse.CourseType == "Must")
        //        {
        //            mapped.ApprovedStatus = ApprovedStatus.CoordinatorApproved;
        //        }
        //        else // it is an approved elective course
        //        {
        //            mapped.ApprovedStatus = ApprovedStatus.InstructorApproved;
        //        }
        //    }
        //    else // reject
        //    {
        //        _studentRepo.GetCourseMapped(courseMappedId).ApprovedStatus = ApprovedStatus.Rejected;
        //    }
        //    _studentRepo.Update();
        //}

        [HttpGet("/GetPendingCourseMapped", Name = "CoordinatorCoursePendingGet")]
        public List<ProposalCourse> GetPendingCourseMapped()
        {
            return _proposalRepo.GetCoordinatorApproved();
        }


    }
}
