using System.ComponentModel.DataAnnotations;

namespace ERMAN.Models
{
    public class Instructor
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Email address is required.")]
        [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "Please enter valid e-mail address")]
        public string Email { get; set; } = null!;

        [Required(ErrorMessage = "AuthId must be provided")]
        public int AuthId { get; set; }
        public string? FirstName { get; set; } = null!;
        public string? LastName { get; set; } = null!;

        public string? Faculty { get; set; }
        public string? Department { get; set; }


        public int? InstructorId { get; set; }

        public virtual List<Course> Courses { get; set; }

        public virtual List<Message> Messages { get; set; }

        public DateTime InsertDate { get; set; } = DateTime.Now;
    }
}
