using ERMAN.Dtos;
using ERMAN.Models;
using Microsoft.EntityFrameworkCore;
using ERMAN.Dtos;


namespace ERMAN.Repositories
{
    public class ChecklistRepository : IGeneralInterface<Checklist, ChecklistDto>
    {
        private readonly ErmanDbContext _dbContext;

        public ChecklistRepository(ErmanDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Add(ChecklistDto checklist)
        {
            var checklistNew = new Checklist
            {
                UserId = checklist.UserId,
                Text = checklist.Text,
                Checked = checklist.Checked,
            };
            _dbContext.ChecklistTable.Add(checklistNew);
            _dbContext.SaveChanges();
        }

        public Checklist Remove(int id)
        {
            Checklist toBeDeleted = _dbContext.ChecklistTable.Find(id);
            if (toBeDeleted != null)
            {
                _dbContext.ChecklistTable.Remove(toBeDeleted);
                _dbContext.SaveChanges();
            }
            return toBeDeleted;
        }

        public Checklist Get(int id)
        {
            Checklist toBeFind = _dbContext.ChecklistTable.Find(id);
            return toBeFind;
        }

        public IEnumerable<Checklist> GetAll( int userId)
        {
            return _dbContext.ChecklistTable.Where(C => C.UserId == userId).ToList();
        }

        public void Update()
        {
            _dbContext.SaveChanges();
        }
    }
}

