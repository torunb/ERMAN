using ERMAN.Dtos;
using ERMAN.Models;
using Microsoft.EntityFrameworkCore;
namespace ERMAN.Repositories
{
    public class CoordinatorRepository : IGeneralInterface<Coordinator,CoordinatorDto>
    {
        private ErmanDbContext _context;

        public CoordinatorRepository(ErmanDbContext _context)
        {
            this._context = _context;
        }

        public void Add(CoordinatorDto entity)
        {
            var coordinatorNew = new Coordinator
            {
                CoordinatorId = entity.CoordinatorId,
                CoordinatorEmailAddress = entity.CoordinatorEmailAddress,
                CoordinatorName = entity.CoordinatorName,
                CoordinatorUniversityId = entity.CoordinatorUniversityId,
              
            };

            _context.CoordinatorTable.Add(coordinatorNew);
            _context.SaveChanges();
        }

        public Coordinator Get(int id)
        {
            return _context.CoordinatorTable.Find(id);
          
        }

        public Coordinator Remove(int id)
        {
            Coordinator toDelete = _context.CoordinatorTable.Find(id);
            if (toDelete != null)
            {
                _context.CoordinatorTable.Remove(toDelete);
                _context.SaveChanges();
            }
            return toDelete;
        }

        public void Update()
        {
            _context.SaveChanges();
        }

        //public IEnumerable<Coordinator> GetCoordinators()
        //{
        //    return _context.CoordinatorTable.ToList();
        //}
        //public Coordinator GetCoordinatorByID(int coordinatorId)
        //{
        //    return _context.CoordinatorTable.Find(coordinatorId);
        //}
        //public void InsertCoordinator(Coordinator coordinator)
        //{
        //    _context.CoordinatorTable.Add(coordinator);
        //}
        //public void DeleteCoordinator(int coordinatorId)
        //{
        //    Coordinator coordinator = _context.CoordinatorTable.Find(coordinatorId);
        //    _context.CoordinatorTable.Remove(coordinator);
        //}

        //public void UpdateCoordinator(Coordinator coordinator)
        //{
        //    _context.Entry(coordinator).State = EntityState.Modified;
        //}
        //public void Save()
        //{
        //    _context.SaveChanges();
        //}



    }
}