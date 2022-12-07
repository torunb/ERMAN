using ERMAN.Models;
using Microsoft.EntityFrameworkCore;

namespace ERMAN.Repositories
{
    public class StudentPlacementsRepository : IDisposable
    {
        private ErmanDbContext context;

        public StudentPlacementsRepository(ErmanDbContext context)
        {
            this.context = context;
        }

        public IEnumerable<StudentPlacement> ToWaitingList()
        {
            return context.StudentPlacements.ToList().Where(x => x.IsInWaitingList);
        }

        public IEnumerable<StudentPlacement> GetStudentPlacements()
        {
            return context.StudentPlacements.ToList();
        }

        public StudentPlacement GetStudentPlacementByID(int id)
        {
            return context.StudentPlacements.Find(id);
        }

        public void InsertStudentPlacement(StudentPlacement studentPlacement)
        {
            context.StudentPlacements.Add(studentPlacement);
        }

        public void DeleteStudentPlacement(int studentPlacementId)
        {
            StudentPlacement studentPlacement = context.StudentPlacements.Find(studentPlacementId);
            context.StudentPlacements.Remove(studentPlacement);
        }

        public void UpdateStudentPlacement(StudentPlacement studentPlacement)
        {
            context.Entry(studentPlacement).State = EntityState.Modified;
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

