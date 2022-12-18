using ERMAN.Dtos;
using ERMAN.Models;
using ERMAN.Repositories;
using ERMAN.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ERMAN.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InstructorController : ControllerBase
    {
        private readonly IGeneralInterface<Instructor, InstructorDto> _instrRepo;
        private readonly StudentRepository _studentRepo;
        private readonly MessagingService _messagingService;
        private readonly MessageRepository _messageRepo;
        private readonly CourseProposalRepository _proposalRepository;
        public InstructorController(IGeneralInterface<Instructor, InstructorDto> instrRepo, StudentRepository studentRepo, MessageRepository messageRepo, MessagingService messagingService, CourseProposalRepository proposalRepository)
        {
            _instrRepo = instrRepo;
            _studentRepo = studentRepo;
            _messagingService = messagingService;
            _messageRepo = messageRepo;
            _proposalRepository = proposalRepository;
        }

        [HttpPost(Name = "InstructorPost")]
        public void Post(InstructorDto faq)
        {
            _instrRepo.Add(faq);
        }

        [HttpDelete("/api/Instructor/ApproveOrReject", Name = "InstructorCourseApproveReject")]
        public void ApproveRejectCourseMapped(int id, int courseMappedId, bool approve, int proposalId)
        {
            if (approve)
            {
                _studentRepo.GetCourseMapped(courseMappedId).ApprovedStatus = ApprovedStatus.InstructorApproved;

                var msgText = "Your course approval was approved";
                var message = new MessageDto
                {
                    messageText = msgText,
                    senderId = -1,
                    receiverId = id,
                };
                _messageRepo.Add(message);
                _messagingService.sendMessage(-1, id, msgText);
            }
            else // reject
            {
                _studentRepo.GetCourseMapped(courseMappedId).ApprovedStatus = ApprovedStatus.Rejected;
            }
            _studentRepo.Update();
            _proposalRepository.Remove(proposalId);
        }
        [HttpDelete("api/Coordinator/GetPendingCourseMapped", Name = "InstructorCoursePendingGet")]
        public List<ProposalCourse> GetPendingCourseMapped()
        {
            return _proposalRepository.GetCoordinatorApproved();
        }

        [HttpGet(Name = "InstructorGet")]
        public Instructor Get(int id)
        {
            return _instrRepo.Get(id);
        }

        [HttpDelete(Name = "InstructorDelete")]
        public Instructor Delete(int id)
        {
            return _instrRepo.Remove(id);
        }


        //[HttpPut(Name = "InstructorPut")]
        //public void Put()
        //{
        //    _instrRepo.Update();
        //}
    }
}
