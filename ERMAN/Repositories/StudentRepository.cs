using ERMAN.Dtos;
using ERMAN.Models;

namespace ERMAN.Repositories
{
    public class StudentRepository 
    {
        private readonly ErmanDbContext _dbContext;

        public StudentRepository(ErmanDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Add(StudentDto student)
        {
            var studentNew = new Student
            {
                StudentEmailAddress = student.StudentEmailAddress,
                StudentName = student.StudentName,
                StudentId = student.StudentId,
                IsRejected = student.IsRejected,
            };

            _dbContext.StudentTable.Add(studentNew);
            _dbContext.SaveChanges();
        }

        public Student Remove(int id)
        {
            Student toBeDeleted = _dbContext.StudentTable.Find(id);
            if(toBeDeleted != null)
            {
                _dbContext.StudentTable.Remove(toBeDeleted);
                _dbContext.SaveChanges();
            }
            return toBeDeleted;
        }

        public Student Get(int id)
        {
            Student toBeFind= _dbContext.StudentTable.Find(id);
            return toBeFind;
        }

        //public Student Update(StudentDto student)
        //{
        //    //_dbContext.SaveChanges();
        //}
    }
}
