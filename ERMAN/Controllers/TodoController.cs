using ERMAN.Dtos;
using ERMAN.Models;
using ERMAN.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace ERMAN.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoController : ControllerBase
    {
        private readonly TodoRepository _todoRepo;

        public TodoController(TodoRepository todoRepo)
        {
            _todoRepo = todoRepo;
        }

        [HttpGet]
        [Authorize(Roles = "student")]
        public IEnumerable<Todo> Get()
        {
            var userId = Convert.ToInt32(HttpContext.User.Claims.FirstOrDefault((claim => claim.Type == "userID")).Value);
            return _todoRepo.GetAll(userId);
        }
    }
}
