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
        private readonly ChecklistRepository _checklistRepository;
        private readonly ErmanDbContext _dbContext;

        public UserService(ChecklistRepository checklistRepository, StudentRepository studentRepository, InstructorRepository instructorRepository, CoordinatorRepository coordinatorRepository, ErmanDbContext dbContext)
        {
            _studentRepository = studentRepository;
            _instructorRepository = instructorRepository;
            _coordinatorRepository = coordinatorRepository;
            _checklistRepository = checklistRepository;
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
                _checklistRepository.AddEmpty(user.AuthId);
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
                    Email = user.Email,
                    AuthId = user.AuthId,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
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
            Coordinator coordinator = _coordinatorRepository.Get(authId);
            Console.WriteLine("authid: " + authId.ToString());

            if (student != null) {
                Console.WriteLine("student");
                var userInfo = new UserInfoDTO
                {
                    authId = student.AuthId,
                    userType = UserType.Student.ToString().ToLower(),
                    email = student.Email,
                    firstName = student.FirstName,
                    lastName = student.LastName,
                    bilkentID = student.StudentId.ToString(),
                    department = student.Department,
                    faculty = student.Faculty,
                    applicationStatus = student.ApplicationStatus,
                    university = student.University != null ? student.University.UniversityName : null,
                    durationPreffered = student.DurationPreffered != null ? student.DurationPreffered.ToString() : null,
                    program = student.Program != null ? student.Program.ToString() : null,
                    coordinatorID = student.CoordinatorId,
                    coordinatorName = student.CoordinatorName,
                };

                Console.WriteLine(userInfo.email);
                return userInfo;
            }
            else if (coordinator != null)
            {
                var userInfo = new UserInfoDTO
                {
                    authId = coordinator.AuthId,
                    userType = UserType.Coordinator.ToString().ToLower(),
                    email = coordinator.Email,
                    firstName = coordinator.FirstName,
                    lastName = coordinator.LastName,
                    department = coordinator.Department,
                    faculty = coordinator.Faculty,
                };

                Console.WriteLine(userInfo.email);
                return userInfo;
            }

            Console.WriteLine("returning null");
            return null;
        }

        public List<UserInfoDTO> GetAll()
        {
            List<Student> students = _studentRepository.GetAll();
            List<Coordinator> coordinators = _coordinatorRepository.GetAll();
            List<UserInfoDTO> result = new List<UserInfoDTO>();

            foreach (Student student in students)
            {
                var userInfo = new UserInfoDTO
                {
                    authId = student.AuthId,
                    userType = UserType.Student.ToString().ToLower(),
                    email = student.Email,
                    firstName = student.FirstName,
                    lastName = student.LastName,
                    bilkentID = student.StudentId.ToString().ToLower(),
                    department = student.Department,
                    faculty = student.Faculty,
                    applicationStatus = student.ApplicationStatus,
                    university = student.University != null ? student.University.UniversityName.ToString().ToLower() : null,
                    durationPreffered = student.DurationPreffered != null ? student.DurationPreffered.ToString().ToLower() : null,
                    program = student.Program != null ? student.Program.ToString().ToLower() : null,
                };
                result.Add(userInfo);
            }

            foreach (Coordinator coordinator in coordinators)
            {
                var userInfo = new UserInfoDTO
                {
                    authId = coordinator.AuthId,
                    userType = UserType.Coordinator.ToString().ToLower(),
                    email = coordinator.Email,
                    firstName = coordinator.FirstName,
                    lastName = coordinator.LastName,
                    department = coordinator.Department,
                    faculty = coordinator.Faculty,
                };
                result.Add(userInfo);
            }

            return result;
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