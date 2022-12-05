using System.ComponentModel.DataAnnotations;

namespace ERMAN.Models
{
    public class Authentication
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Username { get; set; } = null!;

        [Required]
        [StringLength(80)]
        public string Password { get; set; } = null!;

        public UserType Type { get; set; }
    }
}

public enum UserType
{
    Student,
    Instructor,
    Coordinator,
}
