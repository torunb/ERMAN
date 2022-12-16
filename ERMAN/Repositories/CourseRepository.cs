using ERMAN.Dtos;
using ERMAN.Models;
using Microsoft.EntityFrameworkCore;

namespace ERMAN.Repositories
{
    public class CourseRepository
    {
        private readonly ErmanDbContext _dbContext;

        public CourseRepository(ErmanDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Add(CourseDto course)
        {
            var courseNew = new Course
            {
                CourseName = course.CourseName,
                CourseDescription = course.CourseDescription,
                IsForeignUniversity = course.IsForeignUniversity,
                IsElectiveCourse = course.IsElectiveCourse,
                IsMustCourse = course.IsMustCourse,
                CourseType = course.CourseType,
                CourseCredit = course.CourseCredit,
                UniversityId = course.UniversityId,
                CourseCode = course.CourseCode,
            };
            _dbContext.CourseTable.Add(courseNew);
            _dbContext.SaveChanges();
        }

        public Course Remove(int id)
        {
            Course toBeDeleted = _dbContext.CourseTable.Find(id);
            if (toBeDeleted != null)
            {
                _dbContext.CourseTable.Remove(toBeDeleted);
                _dbContext.SaveChanges();
            }
            return toBeDeleted;
        }

        public Course Get(int id)
        {
            Course toBeFind = _dbContext.CourseTable.Find(id);
            return toBeFind;
        }

        public void Update()
        {
            _dbContext.SaveChanges();
        }
    }
}
