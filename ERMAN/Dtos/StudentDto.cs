using System.ComponentModel.DataAnnotations;

namespace ERMAN.Dtos
{
    public class StudentDto
    {
        [Required]
        [StringLength(8, ErrorMessage = "Student id cannot be longer than 8 digits")]
        public int StudentId { get; set; }

        [Required]
        [StringLength(100)]
        public string StudentName { get; set; } = null!;

        [Required]
        [StringLength(360)]
        [RegularExpression(@"^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "Please enter valid e-mail address")]
        public string StudentEmailAddress { get; set; } = null!;
    }

}
