using System.ComponentModel.DataAnnotations;

namespace ERMAN.Models
{
    public class ProposalCourse
    {
        [Key]
        public int Id { get; set; }

        public string? Intensions { get; set; }

        public CourseMapped? Course { get; set; }

        public string? StudentId { get; set; }

        [Required]
        public int AuthId { get; set; }
    }
}
