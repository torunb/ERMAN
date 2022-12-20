using ERMAN.Models;
using System.ComponentModel.DataAnnotations;

namespace ERMAN.Dtos
{
    public class StudentDto
    {
        
        [StringLength(360)]
        [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "Please enter valid e-mail address")]
        public string? Email { get; set; } 

        [StringLength(100)]
        public string? FirstName { get; set; } 

        [StringLength(100)]
        public string? LastName { get; set; } 

        public int StudentId { get; set; }

        public bool IsRejected { get; set; }

        public int AuthId { get; set; }

        public List<Course>? Courses { get; set; }

        public List<CourseMapped>? SelectedCourses { get; set; }

        public int Ranking { get; set; } = 0!;

        public string? Degree { get; set; }

        public string? Faculty { get; set; }

        public double TotalPoints { get; set; }

        public string? Department { get; set; }

        public List<University> UniversityPreference { get; set; } = new List<University>();

        public string? DurationPreffered { get; set; }

        public University? University { get; set; }
        public string? UniversityName { get; set; }

        public string? ApplicationStatus { get; set; }

        public AppliedProgram? Program { get; set; }
    }
}