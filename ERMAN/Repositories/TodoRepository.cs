using ERMAN.Dtos;
using ERMAN.Models;

namespace ERMAN.Repositories
{
    public class TodoRepository 
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

        public IEnumerable<Todo> GetAll(int userId)
        {
            return _dbContext.TodoTable.Where(C => C.UserId == userId).ToList();
        }

        public void Update()
        {
            _dbContext.SaveChanges();
        }
    }
}

