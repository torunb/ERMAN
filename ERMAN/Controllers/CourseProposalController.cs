﻿using ERMAN.Dtos;
using ERMAN.Models;
using ERMAN.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ERMAN.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseProposalController : ControllerBase
    {
        private readonly StudentRepository _studentRepository;
        private readonly CourseProposalRepository _courseProposalRepository;

        public CourseProposalController(StudentRepository studentRepository, CourseProposalRepository courseProposalRepository)
        {
            _studentRepository = studentRepository;
            _courseProposalRepository = courseProposalRepository;
        }

        [HttpPost]
        public ProposalCourse Post(ProposalCourseDto proposedCourse)
        {
            var userId = (int)HttpContext.Items["userID"];
            proposedCourse.Course.ApprovedStatus = ApprovedStatus.Pending;
            proposedCourse.Status = ProposalStatus.WaitingCoordinator;


            var student = _studentRepository.Get(userId);
            student.SelectedCourses.Add(proposedCourse.Course);

            return _courseProposalRepository.Add(proposedCourse);
        }

        [HttpGet("/api/Proposals", Name = "GetAPI")]
        public List<ProposalCourse> Get()
        {
            return _courseProposalRepository.GetWaitingCoordinatorProposal();
        }

        [HttpGet("/api/Proposals/CoordinatorApproved", Name = "GetCoordinatorApprovedAPI")]
        public List<ProposalCourse> GetCoordinatorApproved()
        {
            return _courseProposalRepository.GetCoordinatorApproved();
        }

        [HttpDelete("/api/Proposals", Name = "Remove")]
        public ProposalCourse RemoveProposal(int proposalId)
        {
            return _courseProposalRepository.Remove(proposalId);
        }
    }
}
