using System.ComponentModel.DataAnnotations;

namespace ERMAN.Dtos
{
    public class AuthDto
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Email address is required.")]
        [StringLength(100)]
        public string Username { get; set; } = null!;

        [Required(ErrorMessage = "Password hash is required.")]
        [StringLength(80)]
        public string Password { get; set; } = null!;

        [Required(ErrorMessage = "User type is required.")]
        public UserType Type { get; set; }
    }
}