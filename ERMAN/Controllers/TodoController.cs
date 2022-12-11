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
        [Authorize(Roles = "Student")]
        public IEnumerable<Todo> Get()
        {
            var userId = (int) HttpContext.Items["userID"];
            return _todoRepo.GetAll(userId);
        }

        [HttpPost]
        [Authorize(Roles = "Student")]
        public void Post(TodoDto todo)
        {
            var userId = HttpContext.Items["userID"];
            var userType = HttpContext.Items["userType"];
            todo.UserType = (string) userType;
            todo.UserId = Convert.ToInt32(userId);
            _todoRepo.Add(todo);
        }
    }
}
