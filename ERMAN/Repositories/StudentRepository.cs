using ERMAN.Dtos;
using ERMAN.Models;
using Microsoft.EntityFrameworkCore;

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
                SelectedCourses = student.SelectedCourses,
                Program = student.Program
            };

            _dbContext.StudentTable.Add(studentNew);
            _dbContext.SaveChanges();
        }
        public Student UpdateStudentSelectedCourses(int authId, List<CourseMapped> courses)
        {
            Student studentToUpdate = _dbContext.StudentTable.Where(student => student.AuthId == authId).FirstOrDefault();
            if (studentToUpdate != null)
            {
                studentToUpdate.SelectedCourses = courses;
                _dbContext.StudentTable.Update(studentToUpdate);
                _dbContext.SaveChanges();
            }
            return studentToUpdate;
        }

        public Student Remove(int authId)
        {
            Student toBeDeleted = _dbContext.StudentTable.Where(student => student.AuthId == authId).FirstOrDefault();
            if (toBeDeleted != null)
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

        public Student GetStudentWithCourses(int authId)
        {

            Student student = _dbContext.StudentTable.Include(student => student.SelectedCourses).Where(x => x.AuthId == authId).FirstOrDefault();
            return student;
        }

        public List<Student> GetAll()
        {
            List<Student> student = _dbContext.StudentTable.ToList();
            return student;
        }

        public void Update()
        {
            _dbContext.SaveChanges();
        }
    }
}
