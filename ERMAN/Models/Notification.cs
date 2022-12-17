using System.ComponentModel.DataAnnotations;

namespace ERMAN.Models
{
    public class Notification
    {
            [Key]
            public int Id { get; set; }

            [Required]
            public string Text { get; set; } = null!;

            [Required]
            public int UserId { get; set; }

            [Required]
            public bool Read { get; set; } = false;
    }
}
