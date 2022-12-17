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
    public class CourseProposalController : ControllerBase
    {
        private readonly ErmanDbContext _context;
        private readonly StudentRepository _studentRepository;

        public CourseProposalController(ErmanDbContext context, StudentRepository studentRepository)
        {
            _context = context;
            _studentRepository = studentRepository;
        }

        [HttpPost]
        public ProposalCourse Post(ProposalCourseDto proposedCourse)
        {
            var userId = (int)HttpContext.Items["userID"];

            proposedCourse.Course.ApprovedStatus = ApprovedStatus.Pending;
            var newProposedCourse = new ProposalCourse
            {
                Course = proposedCourse.Course,
                Intensions = proposedCourse.Intensions,
                StudentId = proposedCourse.StudentId,
                AuthId = userId,
            };

            var student = _studentRepository.Get(userId);
            student.SelectedCourses.Add(proposedCourse.Course);
  
            _context.ProposalCourseTable.Add(newProposedCourse);
            _context.SaveChanges();

            return newProposedCourse;
        }

        [HttpGet("/api/Proposals", Name = "GetAPI")]
        public List<ProposalCourse> Get()
        {
            return _context.ProposalCourseTable.Include(proposal=>proposal.Course.BilkentCourse).Include(proposal => proposal.Course.HostCourses).ToList();
        }
    }
}
