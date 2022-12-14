﻿using ERMAN.Dtos;
using ERMAN.Models;

namespace ERMAN.Repositories
{
    public class PlacementStudentRepository
    {
        private readonly ErmanDbContext _dbContext;

        public PlacementStudentRepository(ErmanDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public PlacementStudent Add(PlacementStudentDto placedStu)
        {
            var newStu = new PlacementStudent
            {
                FirstName = placedStu.FirstName,
                LastName = placedStu.LastName,
                StudentId = placedStu.StudentId,
                Faculty = placedStu.Faculty,
                Department = placedStu.Department,
                Degree = placedStu.Degree,
                TotalPoints = placedStu.TotalPoints,
                DurationPreferred = placedStu.DurationPreferred,
                PreferredUniversity = placedStu.PreferredUniversity,
            };
            _dbContext.PlacementStudentTable.Add(newStu);
            _dbContext.SaveChanges();
            return newStu;
        }

        public PlacementStudent Remove(int studentId)
        {
            PlacementStudent toBeDeleted = _dbContext.PlacementStudentTable.Find(studentId);
            if(toBeDeleted != null)
            {
                _dbContext.PlacementStudentTable.Remove(toBeDeleted);
                _dbContext.SaveChanges();
                return toBeDeleted;
            }
            return null;
        }

        public PlacementStudent Get(int studentId)
        {
            return _dbContext.PlacementStudentTable.Find(studentId);
        }

        public List<PlacementStudent> GetAll()
        {
            return _dbContext.PlacementStudentTable.ToList();
        }


        public void DeleteAll()
        {
            for(int i = 0; i < _dbContext.PlacementStudentTable.Count(); i++)
            {
                _dbContext.Remove(GetAll()[i]);
            }
        }
    }
}
