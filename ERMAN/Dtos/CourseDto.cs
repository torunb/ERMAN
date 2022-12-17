using System.ComponentModel.DataAnnotations;

namespace ERMAN.Dtos
{
    public class CourseDto
    {

        public int? AInstructorId { get; set; }

        [Required(ErrorMessage = "Course name must be provided")]
        public string CourseName { get; set; } = null!;
        public bool IsForeignUniversity { get; set; }
        public bool IsElectiveCourse { get; set; }
        public bool IsMustCourse { get; set; }

        public string? CourseType { get; set; }

        [Required(ErrorMessage = "Course credit must be provided")]
        public float CourseCredit { get; set; }

        [Required(ErrorMessage = "University id must be provided")]
        public int UniversityId { get; set; }

        [Required(ErrorMessage = "Course code must be provided")]
        public string CourseCode { get; set; } = null!;

        public DateTime InsertDate { get; set; } = DateTime.Now;
    }
}
