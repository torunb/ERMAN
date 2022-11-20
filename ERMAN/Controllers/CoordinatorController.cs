using ERMAN.Dtos;
using ERMAN.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ERMAN.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoordinatorController : ControllerBase
    {
        private readonly ErmanDbContext _dbContext;

        public CoordinatorController(ErmanDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpPost(Name = "CoordinatorAPI")]
        public Coordinator Post(CoordinatorDto coordinator)
        {
            var coordinatorNew = new Coordinator
            {
                CoordinatorId = coordinator.CoordinatorId,
                CoordinatorEmailAddress = coordinator.CoordinatorEmailAddress,
                CoordinatorName = coordinator.CoordinatorName,
            };
            _dbContext.CoordinatorTable.Add(coordinatorNew);
            _dbContext.SaveChanges();
            return coordinatorNew;
        }
    }
}
