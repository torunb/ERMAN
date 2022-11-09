using System.ComponentModel.DataAnnotations;

namespace ERMAN.Dtos
{
    public class InstructorDto
    {
        [Required]
        public string InstructorName { get; set; } = null!;

        [Required(ErrorMessage = "Email address is required.")]
        [RegularExpression(@"^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "Please enter valid e-mail address")]
        public string InstructorEmailAddress { get; set; } = null!;

        public int InstructorId { get; set; }
    }
}
