using ERMAN.Dtos;
using ERMAN.Models;
using Microsoft.EntityFrameworkCore;
namespace ERMAN.Repositories
{
    public class CoordinatorRepository
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
                Email = entity.Email,
                FirstName = entity.FirstName,
                LastName = entity.LastName,
                CoordinatorUniversityId = entity.CoordinatorUniversityId,
                AuthId = entity.AuthId,
            };

            _context.CoordinatorTable.Add(coordinatorNew);
            _context.SaveChanges();
        }

        public Coordinator Get(int authId)
        {
            Coordinator coord = _context.CoordinatorTable.Where(x => x.AuthId == authId).FirstOrDefault();
            return coord;
        }

        public List<Coordinator> GetAll()
        {
            return _context.CoordinatorTable.ToList();

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