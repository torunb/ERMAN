using ERMAN.Dtos;
using ERMAN.Models;
using ERMAN.Repositories;
using Microsoft.EntityFrameworkCore;

namespace ERMAN.Services
{
    public class UserService
    {
        private readonly StudentRepository _studentRepository;
        private readonly InstructorRepository _instructorRepository;
        private readonly CoordinatorRepository _coordinatorRepository;
        private readonly ErmanDbContext _dbContext;

        public UserService(StudentRepository studentRepository, InstructorRepository instructorRepository, CoordinatorRepository coordinatorRepository, ErmanDbContext dbContext)
        {
            _studentRepository = studentRepository;
            _instructorRepository = instructorRepository;
            _coordinatorRepository = coordinatorRepository;
            _dbContext = dbContext;
        }

        public void Add(UserDto user)
        {
            var userNew = new User
            {
                UserType = user.UserType,
                Email = user.Email,
                FirstName = user.FirstName,
                LastName = user.LastName,
                BilkentId = user.BilkentId,
                Department = user.Department,
                Faculty = user.Faculty,
                University = user.University,
                DurationPreffered = user.DurationPreffered,
                Program = user.Program,
            };

            if (user.UserType == "student")
            {
                var studentNew = new StudentDto
                {
                    StudentEmailAddress = user.Email,
                    StudentName = user.FirstName + " " + user.LastName,
                    StudentId = user.BilkentId,
                };
                _studentRepository.Add(studentNew);
            }
            else if (user.UserType == "instructor")
            {
                var instructorNew = new InstructorDto
                {
                    InstructorEmailAddress = user.Email,
                    InstructorId = user.BilkentId,
                    InstructorName = user.FirstName + " " + user.LastName,

                };
                _instructorRepository.Add(instructorNew);
            }
            else if (user.UserType == "coordinator")
            {
                var coordinatorNew = new CoordinatorDto
                {
                    CoordinatorEmailAddress = user.Email,
                    CoordinatorId = user.BilkentId,
                    CoordinatorName = user.FirstName + " " + user.LastName
                };
                _coordinatorRepository.Add(coordinatorNew);
            }

            _dbContext.UserTable.Add(userNew);
            _dbContext.SaveChanges();
        }

        public User Remove(int id)
        {
            User toBeDeleted = _dbContext.UserTable.Find(id);
            if (toBeDeleted != null)
            {
                _dbContext.UserTable.Remove(toBeDeleted);
                _dbContext.SaveChanges();
            }
            return toBeDeleted;
        }

        public User Get(int id)
        {
            User toBeFind = _dbContext.UserTable.Find(id);
            return toBeFind;
        }

        public void Update()
        {
            _dbContext.SaveChanges();
        }
    }
}
