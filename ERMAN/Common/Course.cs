namespace ERMAN.Common
{
    public class Course
    {
        public int Id { get; set; }
        public string? CourseName { get; set; } = null!;
        public string? CourseDescription { get; set; } = null!;
        public bool? IsForeignUniversity { get; set; }
        public bool? IsElectiveCourse { get; set; }
        public bool? IsMustCourse { get; set; }
        public string? CourseType { get; set; } = null!;
        public float? CourseCredit { get; set; }
        public int? UniversityId { get; set; }
        public string? CourseCode { get; set; } = null!;
        public string? InstructorMail { get; set; } = null!;
        public string? SyllabusLink { get; set; } = null!;
        
    }
}
