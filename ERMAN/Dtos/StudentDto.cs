using ERMAN.Models;
using System.ComponentModel.DataAnnotations;

namespace ERMAN.Dtos
{
    public class StudentDto
    {
        [Required]
        [StringLength(360)]
        [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "Please enter valid e-mail address")]
        public string Email { get; set; } = null!;

        [Required]
        [StringLength(100)]
        public string FirstName { get; set; } = null!;

        [Required]
        [StringLength(100)]
        public string LastName { get; set; } = null!;

        [Required]
        public int StudentId { get; set; }

        public bool IsRejected { get; set; }

        [Required]
        public int AuthId { get; set; }

        public List<Course> Courses { get; set; }
    }

}
