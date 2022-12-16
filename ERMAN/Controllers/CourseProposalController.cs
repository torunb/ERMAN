using ERMAN.Dtos;
using ERMAN.Models;
using ERMAN.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ERMAN.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseProposalController : ControllerBase
    {
        private readonly ErmanDbContext _context;

        public CourseProposalController(ErmanDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public ProposalCourse Post(ProposalCourseDto proposedCourse)
        {
            var userId = (int)HttpContext.Items["userID"];
            var newProposedCourse = new ProposalCourse
            {
                Course = proposedCourse.Course,
                Intensions = proposedCourse.Intensions,
                StudentId = proposedCourse.StudentId,
                AuthId = userId,
            };

            _context.ProposalCourseTable.Add(newProposedCourse);
            _context.SaveChanges();
            return newProposedCourse;
        }

        [HttpGet("/api/Proposals", Name = "GetAPI")]
        public List<ProposalCourse> Get()
        {
            return _context.ProposalCourseTable.ToList();
        }
    }
}
