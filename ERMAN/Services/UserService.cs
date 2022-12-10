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
                    Email = user.Email,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    StudentId = user.BilkentId,
                    AuthId = user.AuthId,
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

        public UserInfoDTO Get(int authId)
        {
            Student student = _studentRepository.Get(authId);

            if (student != null) {
                Console.WriteLine("student");
                var userInfo = new UserInfoDTO
                {
                    userType = UserType.Student,
                    email = student.Email,
                    firstName = student.FirstName,
                    lastName = student.LastName,
                    bilkentID = student.StudentId.ToString(),
                    department = student.Department,
                    faculty = student.Faculty,
                    applicationStatus = student.ApplicationStatus,
                    university = student.University != null ? student.University.UniversityName : null,
                    durationPreffered = student.DurationPreffered != null ? student.DurationPreffered : null,
                    program = student.Program != null ? student.Program : null,
                };

                Console.WriteLine(userInfo.email);
                return userInfo;
            }

            Console.WriteLine("returning null");
            return null;
        }

        //public List<User> GetAll()
        //{
        //}

        //public void Update()
        //{
        //}
    }
}

public class UserInfo
{

}