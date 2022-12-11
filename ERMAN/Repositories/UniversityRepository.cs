using ERMAN.Dtos;
using ERMAN.Models;
using Microsoft.EntityFrameworkCore;

namespace ERMAN.Repositories
{
    public class UniversityRepository
    {

        private ErmanDbContext _context;

        public UniversityRepository(ErmanDbContext _context)
        {
            this._context = _context;
        }
        public void Add(UniversityDto university)
        {
            var uniNew = new University
            {
                UniversityCapacity = university.UniversityCapacity, 
                UniversityName = university.UniversityName, 
            };

            _context.UniversityTable.Add(uniNew);
            _context.SaveChanges();
        }

        public University Remove(int id)
        {
            University toDelete = _context.UniversityTable.Find(id);
            if (toDelete != null)
            {
                _context.UniversityTable.Remove(toDelete);
                _context.SaveChanges();
            }
            return toDelete;
        }

        public University Get(int id)
        {
            return _context.UniversityTable.Find(id);
        }

        public void Update()
        {
            _context.SaveChanges();
        }
    }

}