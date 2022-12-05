using ERMAN.Dtos;
using ERMAN.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ERMAN.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private readonly ErmanDbContext _dbContext;

        public CourseController(ErmanDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpPost(Name = "CourseAPI")]
        public Course Post(CourseDto course)
        {
            var courseNew = new Course
            {
                InstructorId = course.InstructorId,
                CourseName = course.CourseName,
                CourseType = course.CourseType,
                CourseCredit = course.CourseCredit,
                UniversityId = course.UniversityId,
                CourseCode = course.CourseCode,
            };
            _dbContext.CourseTable.Add(courseNew);
            _dbContext.SaveChanges();
            return courseNew;
        }
    }
}
