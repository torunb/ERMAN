using ERMAN.Models;
using System.ComponentModel.DataAnnotations;

namespace ERMAN.Dtos
{
    public class InstructorDto
    {
        [Required(ErrorMessage = "Email address is required.")]
        [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "Please enter valid e-mail address")]
        public string Email { get; set; } = null!;

        public string FirstName { get; set; } = null!;

        public string LastName { get; set; } = null!;

        [Required(ErrorMessage = "Id must be provided")]
        public int AuthId { get; set; }
        public string? Faculty { get; set; }
        public string? Department { get; set; }

        public List<Course>? Courses { get; set; }

        public int? InstructorId { get; set; }
    }
}
