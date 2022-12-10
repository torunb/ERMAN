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
            if (user.UserType == UserType.Student)
            {
                var studentNew = new StudentDto
                {
                    StudentEmailAddress = user.Email,
                    StudentName = user.FirstName + " " + user.LastName,
                    StudentId = user.BilkentId,
                };
                _studentRepository.Add(studentNew);
            }
            else if (user.UserType == UserType.Instructor)
            {
                var instructorNew = new InstructorDto
                {
                    InstructorEmailAddress = user.Email,
                    InstructorId = user.BilkentId,
                    InstructorName = user.FirstName + " " + user.LastName,

                };
                _instructorRepository.Add(instructorNew);
            }
            else if (user.UserType == UserType.Coordinator)
            {
                var coordinatorNew = new CoordinatorDto
                {
                    CoordinatorEmailAddress = user.Email,
                    CoordinatorId = user.BilkentId,
                    CoordinatorName = user.FirstName + " " + user.LastName
                };
                _coordinatorRepository.Add(coordinatorNew);
            }
        }

        //public User Remove(int id)
        //{
        //}

        //public User Get(int id)
        //{
        //}

        //public List<User> GetAll()
        //{
        //}

        //public void Update()
        //{
        //}
    }
}
