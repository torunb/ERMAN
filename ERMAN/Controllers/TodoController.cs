using ERMAN.Dtos;
using ERMAN.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace ERMAN.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoController : ControllerBase
    {
        private readonly ErmanDbContext _dbContext;

        public TodoController(ErmanDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        
        [HttpGet]
        [Authorize(Roles = "student")]
        public IEnumerable<Todo> Get()
        {
            var userIdClaim = Convert.ToInt32(HttpContext.User.Claims.FirstOrDefault((claim => claim.Type == "userID")).Value);
            return _dbContext.TodoTable.Where(C => C.UserId == userIdClaim).ToList();
        }

        [HttpPost]
        [Authorize(Roles = "student")]
        public Todo Post(TodoDto todo)
        {
            var userId = HttpContext.User.Claims.FirstOrDefault((claim => claim.Type == "userID")).Value;
            var userType = HttpContext.User.Claims.FirstOrDefault((claim => claim.Type == ClaimTypes.Role)).Value;
            var todoNew = new Todo
            {
                UserType = userType,
                Text = todo.Text,
                Type = todo.Type,
                Starred = todo.Starred,
                UserId = Convert.ToInt32(userId),
                DueDate = todo.DueDate,
                Done = todo.Done,
            };
            _dbContext.TodoTable.Add(todoNew);
            _dbContext.SaveChanges();
            return todoNew;
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
