using ERMAN.Dtos;
using ERMAN.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ERMAN.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InstructorController : ControllerBase
    {
        private readonly ErmanDbContext _dbContext;

        public InstructorController(ErmanDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpPost(Name = "InstructorAPI")]
        public Instructor Post(InstructorDto instructor)
        {
            var instructorNew = new Instructor
            {
                InstructorId = instructor.InstructorId,
                InstructorEmailAddress = instructor.InstructorEmailAddress,
                InstructorName = instructor.InstructorName,
            };
            _dbContext.InstructorTable.Add(instructorNew);
            _dbContext.SaveChanges();
            return instructorNew;
        }
    }
}
