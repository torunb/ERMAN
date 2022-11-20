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
        public string FAQAnswer { get; set; } = null!;
    }
}
