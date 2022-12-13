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

        [HttpGet("/api/Checklist", Name = "ChecklistGet")]
        public Checklist Get()
        {
            var userId = (int) HttpContext.Items["userID"];
            return _checklistRepo.Get(userId);
        }

        [HttpPut("/api/ChecklistCheck", Name = "ChecklistCheck")]
        public void Check(int index)
        {
            var userId = (int) HttpContext.Items["userID"];
            _checklistRepo.Check(userId, index);
        }

        //[HttpGet("/api/ChecklistAll", Name = "ChecklistGetAll")]
        //public Checklist Get()
        //{
        //    var userId = (int) HttpContext.Items["userID"];
        //    return _checklistRepo.GetAll(userId);
        //}
    }
}
