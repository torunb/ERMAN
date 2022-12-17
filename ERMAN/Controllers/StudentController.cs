using ERMAN.Dtos;
using ERMAN.Models;
using ERMAN.Services;
using ERMAN.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ERMAN.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly StudentRepository _studentRepo;
        private readonly MessagingService _messagingService;
        private readonly MessageRepository _messageRepo;
        public StudentController(StudentRepository studentRepo, MessagingService messagingService, MessageRepository messageRepo)
        {
            _studentRepo = studentRepo;
            _messagingService = messagingService;
            _messageRepo = messageRepo;
        }

        [HttpPost(Name = "StudentPost")]
        public void Post(StudentDto student)
        {
            _studentRepo.Add(student);
        }

        [HttpPut("/api/Student/addCourses", Name = "StudentAddSelecetedCourses")]
        public void PutCourses(List<CourseMapped> courses)
        {
            var userId = (int)HttpContext.Items["userID"];
            _studentRepo.UpdateStudentSelectedCourses(userId, courses);
        }

        [HttpPut("/api/Student/approveStatus", Name = "StudentApproveCourseStatus")]
        public void SetSelectedCourseAs(int id, int mappedId, ApprovedStatus approvedStatus)
        {
            _studentRepo.Get(id).SelectedCourses.FirstOrDefault(x => x.Id == mappedId).ApprovedStatus = approvedStatus;
            _studentRepo.Update();


            var notificationText = "";
            if (approvedStatus == ApprovedStatus.Rejected)
            {
                notificationText = "Your course approval was rejected.";
            }
            else if (approvedStatus == ApprovedStatus.CoordinatorApproved)
            {
                notificationText = "Your course approval was approved by the coordinator, waiting for instructor approval!";
            }
            else if (approvedStatus == ApprovedStatus.InstructorApproved)
            {
                notificationText = "Your course approval was approved!";
            }

            var message = new MessageDto
            {
                messageText = notificationText,
                senderId = -1,
                receiverId = id,
            };
            _messageRepo.Add(message);

            _messagingService.sendMessage(-1, id, notificationText);
        }

        [HttpPut("/api/Student/removeCourse", Name = "StudentRemoveCourse")]
        public void RemoveSelectedCourse(int mappedId)
        {
            var userId = (int)HttpContext.Items["userID"];
            CourseMapped course = _studentRepo.Get(userId).SelectedCourses.FirstOrDefault(x => x.Id == mappedId);
            _studentRepo.Get(userId).SelectedCourses.Remove(course);
            _studentRepo.Update();
        }

        [HttpGet(Name = "StudentGet")]
        public Student Get(int id)
        {
            return _studentRepo.Get(id);
        }

        [HttpGet("/api/Student/all", Name = "StudentGetAll")]
        public List<Student> GetAll()
        {
            return _studentRepo.GetAll();
        }

        [HttpGet("/api/Student/SelectedCourses", Name = "StudentGetSelecetedCourses")]
        public List<CourseMapped> GetSelectedCourses()
        {
            var userId = (int)HttpContext.Items["userID"];
            return _studentRepo.GetStudentWithCourses(userId).SelectedCourses;
        }

        [HttpDelete(Name = "StudentDelete")]
        public Student Delete(int id)
        {
            return _studentRepo.Remove(id);
        }

        //[HttpPut(Name = "StudentPut")]
        //public void Put()
        //{
        //    _studentRepo.Update();
        //}

    }
}
