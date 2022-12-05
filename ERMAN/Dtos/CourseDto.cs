namespace ERMAN.Dtos
{
    public class CourseDto
    {
        public int InstructorId { get; set; }

        public string CourseName { get; set; } = null!;

        public string CourseType { get; set; } = null!;

        public float CourseCredit { get; set; }

        public int UniversityId { get; set; }

        public string CourseCode { get; set; } = null!;
    }
}
