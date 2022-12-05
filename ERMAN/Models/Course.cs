
using System.ComponentModel.DataAnnotations;

namespace ERMAN.Models
{
    public class Course
    {
        [Key]
        public int Id { get; set; }

        public int InstructorId { get; set; }

        public string CourseName { get; set; } = null!;

        public string CourseType { get; set; } = null!;

        public float CourseCredit { get; set; }

        public int UniversityId { get; set; }

        public string CourseCode { get; set; } = null!;

        public DateTime InsertDate { get; set; } = DateTime.Now;
    }
}
