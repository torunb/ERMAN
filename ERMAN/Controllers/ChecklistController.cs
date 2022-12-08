using ERMAN.Dtos;
using ERMAN.Models;
using ERMAN.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ERMAN.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChecklistController : ControllerBase
    {
        private readonly ChecklistRepository _checklistRepo;
        public ChecklistController(ChecklistRepository checklistRepo)
        {
            _checklistRepo = checklistRepo;
        }

        [HttpPost(Name = "ChecklistPost")]
        public void Post(ChecklistDto checklist)
        {
            _checklistRepo.Add(checklist);
        }


        [HttpGet("/api/Checklist", Name = "ChecklistGet")]
        public Checklist Get(int id)
        {
            return _checklistRepo.Get(id);
        }


        [HttpGet("/api/ChecklistAll", Name = "ChecklistGetAll")]
        public IEnumerable<Checklist> Get()
        {

            var userId = Convert.ToInt32(HttpContext.User.Claims.FirstOrDefault((claim => claim.Type == "userID")).Value);
            return _checklistRepo.GetAll(userId);
        }

        [HttpDelete(Name = "ChecklistDelete")]
        public Checklist Delete(int id)
        {
            return _checklistRepo.Remove(id);
        }

        [HttpPut(Name = "ChecklistPut")]
        public void Put()
        {
            _checklistRepo.Update();
        }
    }
}
