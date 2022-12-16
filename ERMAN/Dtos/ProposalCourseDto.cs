using ERMAN.Models;

namespace ERMAN.Dtos
{
    public class ProposalCourseDto
    {
        public string? Intensions { get; set; }

        public CourseMapped? Course { get; set; }

        public string? StudentId { get; set; }
    }
}
