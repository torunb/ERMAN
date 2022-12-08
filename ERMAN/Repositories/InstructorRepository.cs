using ERMAN.Dtos;
using ERMAN.Models;

namespace ERMAN.Repositories
{
    public class InstructorRepository
    {
        private readonly ErmanDbContext _dbContext;

        public InstructorRepository(ErmanDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Add(InstructorDto instructor)
        {
            var instructorNew = new Instructor
            {
                InstructorId = instructor.InstructorId,
                InstructorEmailAddress = instructor.InstructorEmailAddress,
                InstructorName = instructor.InstructorName,
            };

            _dbContext.InstructorTable.Add(instructorNew);
            _dbContext.SaveChanges();
        }

        public Instructor Remove(int id)
        {
            Instructor toBeDeleted = _dbContext.InstructorTable.Find(id);
            if (toBeDeleted != null)
            {
                _dbContext.InstructorTable.Remove(toBeDeleted);
                _dbContext.SaveChanges();
            }
            return toBeDeleted;
        }

        public Instructor Get(int id)
        {
            Instructor toBeFind = _dbContext.InstructorTable.Find(id);
            return toBeFind;
        }

        public void Update()
        {
            _dbContext.SaveChanges();
        }
    }
}
