using ERMAN.Dtos;
using ERMAN.Models;
using ERMAN.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace ERMAN.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UniversityController : ControllerBase
    {
        private readonly IGeneralInterface<University, UniversityDto> repository;

        public UniversityController(IGeneralInterface<University, UniversityDto> repository)
        {
            this.repository = repository;
        }

        [HttpPost("university/add", Name = "UniversityAPI")]
        public void Post(UniversityDto university)
        {
            repository.Add(university);
        }
    }
}
