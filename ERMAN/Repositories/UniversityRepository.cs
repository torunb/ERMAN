using ERMAN.Models;
using Microsoft.EntityFrameworkCore;

namespace ERMAN.Repositories
{
    public class UniversityRepository : IDisposable
    {

        private ErmanDbContext _context;

        public UniversityRepository(ErmanDbContext _context)
        {
            this._context = _context;
        }
        public IEnumerable<University> GetUniversities()
        {
            return _context.UniversityTable.ToList();
        }
        public University GetUniversityByID(int universityId)
        {
            return _context.UniversityTable.Find(universityId);
        }

        public void InsertUniversity(University university)
        {
            _context.UniversityTable.Add(university);
        }

        public void DeleteUniversity(int universityId)
        {
            _context.UniversityTable.Remove(_context.UniversityTable.Find(universityId));
        }
        public void UpdateUniversity(University university)
        {
            _context.Entry(university).State = EntityState.Modified;
        }
        public void Save()
        {
            _context.SaveChanges();
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
        // ~UniversityRepository()
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