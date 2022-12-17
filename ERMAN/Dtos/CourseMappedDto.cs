using ERMAN.Models;
using System.ComponentModel.DataAnnotations;

namespace ERMAN.Dtos
{
    public class CourseMappedDto
    {

        [Required(ErrorMessage = "Bilkent university courses be provided")]
        public Course BilkentCourse { get; set; } = null!;

        [Required(ErrorMessage = "Host university courses must be provided")]
        public List<Course> HostCourses { get; set; } = null!;

        public ApprovedStatus ApprovedStatus { get; set; }
    }
}
