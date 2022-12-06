using ERMAN.Models;
using Microsoft.EntityFrameworkCore;

namespace ERMAN.Repositories
{
    public class ChecklistRepository : IDisposable
    {
        private ErmanDbContext context;

        public ChecklistRepository(ErmanDbContext context)
        {
            this.context = context;
        }

        public IEnumerable<Checklist> GetChecklists()
        {
            return context.Checklists.ToList();
        }

        public Checklist GetChecklisteByID(int id)
        {
            return context.Checklists.Find(id);
        }

        public void InsertChecklist(Checklist checklist)
        {
            context.Checklists.Add(checklist);
        }

        public void DeleteChecklist(int checklistId)
        {
            Checklist checklist = context.Checklists.Find(checklistId);
            context.Checklists.Remove(checklist);
        }

        public void UpdateChecklist(Checklist checklist)
        {
            context.Entry(checklist).State = EntityState.Modified;
        }

        public void Save()
        {
            context.SaveChanges();
        }




        private bool disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}

