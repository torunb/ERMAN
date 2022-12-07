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

        private readonly IGeneralInterface<Todo, TodoDto> _todoRepo;

        public TodoController(IGeneralInterface<Todo, TodoDto> todoRepo)
        {
            _todoRepo = todoRepo;
        }
        
        [HttpGet]
        [Authorize(Roles = "student")]
        public IEnumerable<Todo> Get()
        {
            return _todoRepo.Get();
        }

        [HttpPost]
        [Authorize(Roles = "student")]
        public void Post(TodoDto todo)
        {
            var userId = HttpContext.User.Claims.FirstOrDefault((claim => claim.Type == "userID")).Value;
            var userType = HttpContext.User.Claims.FirstOrDefault((claim => claim.Type == ClaimTypes.Role)).Value;
            todo.UserType = userType;
            todo.UserId = Convert.ToInt32(userId);
            _todoRepo.Add(todo);
        }

        //[HttpGet]
        //public Todo Get(TodoDto todo)
        //{
        //    var todoNew = new Todo
        //    {
        //        UserType = todo.UserType,
        //        Text = todo.Text,
        //        Type = todo.Type,
        //        Starred = todo.Starred,
        //        DueDate = todo.DueDate,
        //        Done = todo.Done,
        //    };
        //    _dbContext.TodoTable.Add(todoNew);
        //    _dbContext.SaveChanges();
        //    return todoNew;
        //}

        //[HttpPost]
        //public Todo Post(TodoDto todo)
        //{
        //    var todoNew = new Todo
        //    {
        //        UserType = todo.UserType,
        //        Text = todo.Text,
        //        Type = todo.Type,
        //        Starred = todo.Starred,
        //        DueDate = todo.DueDate,
        //        Done = todo.Done,
        //    };
        //    _dbContext.TodoTable.Add(todoNew);
        //    _dbContext.SaveChanges();
        //    return todoNew;
        //}
    }
}
