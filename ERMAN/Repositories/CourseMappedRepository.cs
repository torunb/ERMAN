﻿using ERMAN.Dtos;
using ERMAN.Models;
using Microsoft.EntityFrameworkCore;
using ERMAN.Dtos;


namespace ERMAN.Repositories
{
    public class CourseMappedRepository
    {
        private readonly ErmanDbContext _dbContext;

        public CourseMappedRepository(ErmanDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Add(CourseMappedDto courseMapped)
        {
            var courseMappedNew = new CourseMapped
            {
                ApprovedStatus = courseMapped.ApprovedStatus,
                BilkentCourse = courseMapped.BilkentCourse,
                HostCourses = courseMapped.HostCourses,
            };
            _dbContext.CourseMappedTable.Add(courseMappedNew);
            _dbContext.SaveChanges();
        }
        /*
        public void AddEmpty(int userId)
        {
            var courseMappedNew = new CourseMapped
            { 
                Checked = new bool[17],
                UserId = userId
            };
            _dbContext.CourseMappedTable.Add(courseMappedNew);
            _dbContext.SaveChanges();
        }
        */

        public void Remove(int id)
        {
            CourseMapped toBeDeleted = _dbContext.CourseMappedTable.Find(id);
            if (toBeDeleted != null)
            {
                _dbContext.CourseMappedTable.Remove(toBeDeleted);
                _dbContext.SaveChanges();
            }
        }

        public CourseMapped Get(int id)
        {
            CourseMapped toBeFind = _dbContext.CourseMappedTable.Find(id);
            return toBeFind;
        }
        public IEnumerable<CourseMapped> GetAll()
        {
            return _dbContext.CourseMappedTable.ToList();
        }

        public IEnumerable<CourseMapped> GetCoordinatorApproved()
        {
            return _dbContext.CourseMappedTable.Include(courseMapped => courseMapped.BilkentCourse).Include(courseMapped => courseMapped.HostCourses).Where(x => x.ApprovedStatus == ApprovedStatus.CoordinatorApproved).ToList();
        }
        public IEnumerable<CourseMapped> GetInstructorApproved()
        {
            return _dbContext.CourseMappedTable.Include(courseMapped => courseMapped.BilkentCourse).Include(courseMapped => courseMapped.HostCourses).Where(x => x.ApprovedStatus == ApprovedStatus.InstructorApproved).ToList();
        }

        public IEnumerable<CourseMapped> GetRejected()
        {
            return _dbContext.CourseMappedTable.Where(x => x.ApprovedStatus == ApprovedStatus.Rejected).ToList();
        }

        public IEnumerable<CourseMapped> GetPending()
        {
            return _dbContext.CourseMappedTable.Where(x => x.ApprovedStatus == ApprovedStatus.Pending).ToList();
        }

        public void Update()
        {
            _dbContext.SaveChanges();
        }
    }
}

