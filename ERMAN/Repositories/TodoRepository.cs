using ERMAN.Dtos;
using ERMAN.Models;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using ERMAN.Dtos;
using ERMAN.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace ERMAN.Repositories
{
    public class TodoRepository : IGeneralInterface<Todo, TodoDto>
    {
        private readonly ErmanDbContext _dbContext;

        public TodoRepository(ErmanDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Add(TodoDto todo)
        {
            var todoNew = new Todo
            {
                UserType = todo.UserType,
                Text = todo.Text,
                Type = todo.Type,
                Starred = todo.Starred,
                UserId = todo.UserId,
                DueDate = todo.DueDate,
                Done = todo.Done,
            };
            _dbContext.TodoTable.Add(todoNew);
            _dbContext.SaveChanges();
        }

        public Todo Remove(int id)
        {
            Todo toBeDeleted = _dbContext.TodoTable.Find(id);
            if (toBeDeleted != null)
            {
                _dbContext.TodoTable.Remove(toBeDeleted);
                _dbContext.SaveChanges();
            }
            return toBeDeleted;
        }

        public Todo Get(int id)
        {
            Todo toBeFind = _dbContext.TodoTable.Find(id);
            return toBeFind;
        }

        public IEnumerable<Todo> Get()
        {
            var userIdClaim = Convert.ToInt32(HttpContext.User.Claims.FirstOrDefault((claim => claim.Type == "userID")).Value);
            return _dbContext.TodoTable.Where(C => C.UserId == userIdClaim).ToList();
        }

        public void Update()
        {
            _dbContext.SaveChanges();
        }
    }
}

