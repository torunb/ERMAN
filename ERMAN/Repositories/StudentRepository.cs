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
                Ranking = student.Ranking,
                TotalPoints = student.TotalPoints,
                FirstName = student.FirstName,
                LastName = student.LastName,
                Degree = student.Degree,
                Faculty = student.Faculty,
                Department = student.Department,
                UniversityPreference = student.UniversityPreference,
                DurationPreffered = student.DurationPreffered,
                Email = student.Email,
                StudentId = student.StudentId,
                IsRejected = student.IsRejected,
                AuthId = student.AuthId,
                University = student.University,
                ApplicationStatus = student.ApplicationStatus,
                Program = student.Program
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

        public void DeleteAll()
        {
            for (int i = 0; i < GetAll().Count; i++)
            {
                _dbContext.Remove(GetAll()[i]);
            }
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
