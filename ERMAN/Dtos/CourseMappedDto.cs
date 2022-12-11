using ERMAN.Models;
using System.ComponentModel.DataAnnotations;

namespace ERMAN.Dtos
{
    public class CourseMappedDto
    {
        public bool ApprovedStatus { get; set; }

        [Required(ErrorMessage = "Bilkent university courses be provided")]
        public Course BilkentCourse { get; set; } = null!;

        [Required(ErrorMessage = "Host university courses must be provided")]
        public Course[] HostCourses { get; set; } = null!;

        [Required(ErrorMessage = "Department that evaluates must be provided")]
        public string Department { get; set; }

        [Required(ErrorMessage = "Student id must be provided")]
        public int StudentId { get; set; }
    }
}
