﻿using ERMAN.Dtos;
using ERMAN.Models;
using Microsoft.EntityFrameworkCore;

namespace ERMAN.Repositories
{
    public class CourseProposalRepository
    {
        private readonly ErmanDbContext _context;

        public CourseProposalRepository(ErmanDbContext context)
        {
            _context = context;
        }

        public ProposalCourse Remove(int proposedId)
        {
            ProposalCourse toBeDeleted = _context.ProposalCourseTable.FirstOrDefault(proposal => proposal.Id == proposedId);
            if (toBeDeleted != null)
            {
                _context.ProposalCourseTable.Remove(toBeDeleted);
                _context.SaveChanges();
            }
            return toBeDeleted;
        }

        public ProposalCourse Add(ProposalCourseDto proposedCourse)
        {
            proposedCourse.Course.ApprovedStatus = ApprovedStatus.Pending;
            var newProposedCourse = new ProposalCourse
            {
                Course = proposedCourse.Course,
                Intensions = proposedCourse.Intensions,
                StudentId = proposedCourse.StudentId,
                AuthId = proposedCourse.AuthId,
            };

            _context.ProposalCourseTable.Add(newProposedCourse);
            _context.SaveChanges();

            return newProposedCourse;
        }

        public ProposalCourse Get(int proposalID)
        {
            return _context.ProposalCourseTable.Find(proposalID);
        }

        public List<ProposalCourse> GetAll()
        {
            return _context.ProposalCourseTable.Include(proposal => proposal.Course.BilkentCourse).Include(proposal => proposal.Course.HostCourses).ToList();
        }

        public List<ProposalCourse> GetWaitingCoordinatorProposal()
        {
            return _context.ProposalCourseTable.Where(proposal => proposal.Status == ProposalStatus.WaitingCoordinator).ToList();
        }

        public List<ProposalCourse> GetCoordinatorApproved()
        {
            return _context.ProposalCourseTable.Where(proposal => proposal.Course.ApprovedStatus == ApprovedStatus.CoordinatorApproved).ToList();
        }

        public void Update()
        {
            _context.SaveChanges();
        }
    }
}
