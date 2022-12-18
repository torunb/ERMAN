using ERMAN.Models;
using System.ComponentModel.DataAnnotations;

namespace ERMAN.Dtos
{
    public class ProposalCourseDto
    {
        public string? Intensions { get; set; }

        public CourseMapped? Course { get; set; }

        public ProposalStatus Status { get; set; }

        public string? StudentId { get; set; }

        public int AuthId { get; set; }
    }
}
