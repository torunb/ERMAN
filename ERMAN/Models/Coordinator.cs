using System.ComponentModel.DataAnnotations;

namespace ERMAN.Models
{
    public class Coordinator
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage ="Email address is required.")]
        [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "Please enter valid e-mail address")]
        public string CoordinatorEmailAddress { get; set; } = null!;

        [Required]
        [StringLength(100)]
        public string CoordinatorName { get; set; } = null!;

        [Required(ErrorMessage = "Id must be provided")]
        public int CoordinatorId { get; set; }
    }
}
