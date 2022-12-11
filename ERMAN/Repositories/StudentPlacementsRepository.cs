using ERMAN.Dtos;
using ERMAN.Models;
using Microsoft.EntityFrameworkCore;

namespace ERMAN.Repositories
{
    public class StudentPlacementsRepository
    {
        private ErmanDbContext _dbContext;

        public StudentPlacementsRepository(ErmanDbContext context)
        {
            _dbContext = context;
        }

        public void Add(StudentPlacementDto placement)
        {
            var placementNew = new StudentPlacement
            {
                TotalPoints = placement.TotalPoints,
                StudentId = placement.StudentId,
                StudentFirstName = placement.StudentFirstName,
                StudentLastName = placement.StudentLastName,
                Degree = placement.Degree,
                Faculty = placement.Faculty,
                Department = placement.Department,
                UniversityChoices = placement.UniversityChoices,
                DurationPrefered = placement.DurationPrefered,
                
            };

            _dbContext.StudentPlacements.Add(placementNew);
            _dbContext.SaveChanges();
        }

        public StudentPlacement Remove(int id)
        {
            StudentPlacement toDelete = _dbContext.StudentPlacements.Find(id);
            if (toDelete != null)
            {
                _dbContext.StudentPlacements.Remove(toDelete);
                _dbContext.SaveChanges();
            }
            return toDelete;
        }

        public StudentPlacement Get(int id)
        {
            StudentPlacement toFind = _dbContext.StudentPlacements.Find(id);
            return toFind;
        }

        public void Update()
        {
            _dbContext.SaveChanges();
        }
    }
}