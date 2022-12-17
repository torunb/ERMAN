using System.ComponentModel.DataAnnotations;

namespace ERMAN.Models
{
    public class CourseMapped
    {
        [Key]
        public int Id { get; set; }

        public ApprovedStatus ApprovedStatus { get; set; }

        [Required(ErrorMessage = "Bilkent university courses be provided")]
        public virtual Course BilkentCourse { get; set; } = null!;

        [Required(ErrorMessage = "Host university courses must be provided")]
        public virtual List<Course> HostCourses { get; set; } = null!;

        [Required(ErrorMessage = "Department that evaluates must be provided")]
        public string Department { get; set; } = null!;
    }
}

public enum ApprovedStatus {
    Approved,
    Rejected,
    Pending
}
