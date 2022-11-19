using System.ComponentModel.DataAnnotations;

namespace ERMAN.Models
{
    public class FAQItem
    {
        [Key]
        public int FAQItemId { get; set; }


        [Required(ErrorMessage = "FAQ question required.")]
        public string FAQQuestion { get; set; } = null!;

        [Required(ErrorMessage = "FAQ answer must be provided")]
        public int FAQAnswer { get; set; }

        public bool IsChecked { get; set; }

        [Required(ErrorMessage = "User id must be provided")]
        public int UserId { get; set; }
    }
}
