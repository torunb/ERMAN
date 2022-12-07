using ERMAN.Dtos;
using ERMAN.Models;
using Microsoft.AspNetCore.Mvc;

namespace ERMAN.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UniversityController : ControllerBase
    {
        private readonly ErmanDbContext _dbContext;

        public UniversityController(ErmanDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpPost(Name = "UniversityAPI")]
        public University Post(UniversityDto university)
        {
            var universityNew = new University
            {
                UniversityName = university.UniversityName,
                UniversityCapacity = university.UniversityCapacity,
            };
            _dbContext.UniversityTable.Add(universityNew);
            _dbContext.SaveChanges();

            return universityNew;
        }
    }
}
