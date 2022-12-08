using System.ComponentModel.DataAnnotations;

namespace ERMAN.Models
{
    public class Instructor
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Email address is required.")]
        [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "Please enter valid e-mail address")]
        public string InstructorEmailAddress { get; set; } = null!;

        [Required]
        public string InstructorName { get; set; } = null!;

        [Required(ErrorMessage = "Id must be provided")]
        public int InstructorId { get; set; }

        public List<Course> Courses { get; set; }

        public List<Message> Messages { get; set; }

        public DateTime InsertDate { get; set; } = DateTime.Now;
    }
}
