using Microsoft.EntityFrameworkCore;

namespace ERMAN.Models
{
    public class ToDoRepository : IDisposable
    {
        private ErmanDbContext context;

        public ToDoRepository(ErmanDbContext context)
        {
            this.context = context;
        }

        public IEnumerable<Todo> Gettodos()
        {
            return context.Todos.ToList();
        }

        public Todo GetToDoeByID(int id)
        {
            return context.Todos.Find(id);
        }

        public void InsertToDo(Todo toDo)
        {
            context.Todos.Add(toDo);
        }

        public void DeleteToDo(int toDoId)
        {
            Todo todo = context.Todos.Find(toDoId);
            context.Todos.Remove(todo);
        }

        public void UpdateToDo(Todo toDo)
        {
            context.Entry(toDo).State = EntityState.Modified;
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

