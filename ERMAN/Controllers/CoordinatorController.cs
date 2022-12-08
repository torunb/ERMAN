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
        private readonly IGeneralInterface<Coordinator,CoordinatorDto> repository;

        public CoordinatorController(CoordinatorRepository repository)
        {
            this.repository = repository;
        }

        [HttpPost("coordinator/add", Name = "CoordinatorAPI")]
        public void Post(CoordinatorDto coordinator)
        {
            repository.Add(coordinator);
            
        }


    }
}
