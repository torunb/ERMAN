using System.ComponentModel.DataAnnotations;

namespace ERMAN.Models
{
    public class Coordinator
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage ="Email address is required.")]
        [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "Please enter valid e-mail address")]
        public string Email { get; set; } = null!;

        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        [Required(ErrorMessage = "AuthId must be provided")]
        public int AuthId { get; set; }

        public int? CoordinatorUniversityId { get; set; }

        public string? Faculty { get; set; }
        public string? Department { get; set; }

        public virtual List<Message> Messages { get; set; }

        public DateTime InsertDate { get; set; } = DateTime.Now;
    }
}
