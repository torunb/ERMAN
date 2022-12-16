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
            var newProposedCourse = new ProposalCourse
            {
                Course = proposedCourse.Course,
                Intensions = proposedCourse.Intensions,
                StudentId = proposedCourse.StudentId,
            };

            _context.ProposalCourseTable.Add(newProposedCourse);
            _context.SaveChanges();
            return newProposedCourse;
        }
    }
}
