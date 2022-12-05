using System.ComponentModel.DataAnnotations;

namespace ERMAN.Dtos
{
    public class MessageDto
    {
        [Key]
        public int Id { get; set; }

        public string messageText { get; set; }

        public string senderType { get; set; }


        [Required]
        public int senderId { get; set; }

        public string receiverType { get; set; }

        [Required]
        public int receiverId { get; set; }
    }
}
