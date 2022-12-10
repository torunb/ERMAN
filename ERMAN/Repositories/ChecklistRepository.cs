using ERMAN.Dtos;
using ERMAN.Models;
using Microsoft.EntityFrameworkCore;
using ERMAN.Dtos;


namespace ERMAN.Repositories
{
    public class ChecklistRepository
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
                Checked = checklist.Checked,
            };
            _dbContext.ChecklistTable.Add(checklistNew);
            _dbContext.SaveChanges();
        }

        public void AddEmpty(int userId)
        {
            var checklistNew = new Checklist
            {
                Checked = new bool[17],
                UserId = userId
            };
            _dbContext.ChecklistTable.Add(checklistNew);
            _dbContext.SaveChanges();
        }

        public void Check(int userId, int index)
        {

            Checklist toBeEdited = _dbContext.ChecklistTable.Where(x => x.UserId == userId).First();

            if (toBeEdited == null || index > 16) return;

            if (toBeEdited.Checked[index])
                toBeEdited.Checked[index] = false;
            else
                toBeEdited.Checked[index] = true;

            _dbContext.ChecklistTable.Update(toBeEdited);
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
            return _dbContext.ChecklistTable.Where(x => x.UserId == userId).ToList();
        }

        public void Update()
        {
            _dbContext.SaveChanges();
        }
    }
}

