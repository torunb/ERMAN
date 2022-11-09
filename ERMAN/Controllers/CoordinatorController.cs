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
        [HttpPost(Name = "CoordinatorAPI")]
        public Coordinator Post(CoordinatorDto coordinator)
        {
            var coordinatorNew = new Coordinator
            {
                CoordinatorId = coordinator.CoordinatorId,
                CoordinatorEmailAddress = coordinator.CoordinatorEmailAddress,
                CoordinatorName = coordinator.CoordinatorName,
            };
            return coordinatorNew;
        }
    }
}
