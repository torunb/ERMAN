using ERMAN.Dtos;
using ERMAN.Models;
using Microsoft.AspNetCore.Mvc;

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
        public Todo Get(TodoDto todo)
        {
            var todoNew = new Todo
            {
                UserType = todo.UserType,
                Text = todo.Text,
                Type = todo.Type,
                Starred = todo.Starred,
                DueDate = todo.DueDate,
                Done = todo.Done,
            };
            _dbContext.TodoTable.Add(todoNew);
            _dbContext.SaveChanges();
            return todoNew;
        }

        [HttpPost]
        public Todo Post(TodoDto todo)
        {
            var todoNew = new Todo
            {
                UserType = todo.UserType,
                Text = todo.Text,
                Type = todo.Type,
                Starred = todo.Starred,
                DueDate = todo.DueDate,
                Done = todo.Done,
            };
            _dbContext.TodoTable.Add(todoNew);
            _dbContext.SaveChanges();
            return todoNew;
        }
    }
}
