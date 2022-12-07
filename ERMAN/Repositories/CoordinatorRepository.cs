using ERMAN.Models;
using Microsoft.EntityFrameworkCore;
namespace ERMAN.Repositories
{
    public class CoordinatorRepository : IDisposable
    {
        private ErmanDbContext _context;
        
        public IEnumerable<Coordinator> GetCoordinators()
        {
            return _context.CoordinatorTable.ToList();
        }
        public Coordinator GetCoordinatorByID(int coordinatorId)
        {
            return _context.CoordinatorTable.Find(coordinatorId);
        }
        public void InsertCoordinator(Coordinator coordinator)
        {
            _context.CoordinatorTable.Add(coordinator);
        }
        public void DeleteCoordinator(int coordinatorId)
        {
            Coordinator coordinator = _context.CoordinatorTable.Find(coordinatorId);
            _context.CoordinatorTable.Remove(coordinator);
        }

        public void UpdateCoordinator(Coordinator coordinator)
        {
            _context.Entry(coordinator).State = EntityState.Modified;
        }
        public void Save()
        {
            _context.SaveChanges();
        }


        public CoordinatorRepository(ErmanDbContext _context)
        {
            this._context = _context;
        }

        private bool disposedValue;
        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects)
                }

                // TODO: free unmanaged resources (unmanaged objects) and override finalizer
                // TODO: set large fields to null
                disposedValue = true;
            }
        }

        // // TODO: override finalizer only if 'Dispose(bool disposing)' has code to free unmanaged resources
        // ~CoordinatorRepository()
        // {
        //     // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
        //     Dispose(disposing: false);
        // }

        public void Dispose()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}