using System.ComponentModel.DataAnnotations;

namespace ERMAN.Models
{
    public class CourseMapped
    {
        [Key]
        public int Id { get; set; }

        public ApprovedStatus ApprovedStatus { get; set; }

        [Required(ErrorMessage = "Bilkent university courses be provided")]
        public Course BilkentCourse { get; set; } = null!;

        [Required(ErrorMessage = "Host university courses must be provided")]
        public List<Course> HostCourses { get; set; } = null!;

        [Required(ErrorMessage = "Department that evaluates must be provided")]
        public string Department { get; set; } = null!;

        [Required(ErrorMessage = "Student id must be provided")]
        public int StudentId { get; set; }
    }
}

public enum ApprovedStatus {
    Approved,
    Rejected,
    Pending
}
