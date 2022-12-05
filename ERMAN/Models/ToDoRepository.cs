using Microsoft.EntityFrameworkCore;

namespace ERMAN.Models
{
    public class TodoRepository : IDisposable
    {
        private ErmanDbContext context;

        public TodoRepository(ErmanDbContext context)
        {
            this.context = context;
        }

        public IEnumerable<Todo> GetTodos()
        {
            return context.Todos.ToList();
        }

        public Todo GetTodoByID(int id)
        {
            return context.Todos.Find(id);
        }

        public void InsertTodo(Todo todo)
        {
            context.Todos.Add(todo);
        }

        public void DeleteTodo(int todoId)
        {
            Todo todo = context.Todos.Find(todoId);
            context.Todos.Remove(todo);
        }

        public void UpdateToDo(Todo todo)
        {
            context.Entry(todo).State = EntityState.Modified;
        }

        public void Save()
        {
            context.SaveChanges();
        }


        private bool disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}

