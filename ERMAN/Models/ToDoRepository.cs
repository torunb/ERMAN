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

        public IEnumerable<ToDo> GetToDos()
        {
            return context.ToDos.ToList();
        }

        public ToDo GetToDoeByID(int id)
        {
            return context.ToDos.Find(id);
        }

        public void InsertToDo(ToDo toDo)
        {
            context.ToDos.Add(toDo);
        }

        public void DeleteToDo(int toDoId)
        {
            ToDo toDo = context.ToDos.Find(toDoId);
            context.ToDos.Remove(toDo);
        }

        public void UpdateToDo(ToDo toDo)
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

