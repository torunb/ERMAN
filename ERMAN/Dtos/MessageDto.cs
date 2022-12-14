using System.ComponentModel.DataAnnotations;

namespace ERMAN.Dtos
{
    public class MessageDto
    {
        [Key]
        public int Id { get; set; }

        public string messageText { get; set; }

        [Required]
        public int senderId { get; set; }

        [Required]
        public int receiverId { get; set; }
    }
}
