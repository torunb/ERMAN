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
                Email = student.Email,
                FirstName = student.FirstName,
                LastName = student.LastName,
                StudentId = student.StudentId,
                IsRejected = student.IsRejected,
                AuthId = student.AuthId,
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

        public Student Get(int authId)
        {
            Student student = _dbContext.StudentTable.Where(x => x.AuthId == authId).FirstOrDefault();
            return student;
        }

        public List<Student> GetAll()
        {
            List<Student> student = _dbContext.StudentTable.ToList();
            return student;
        }
    }
}
