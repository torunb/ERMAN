using System.ComponentModel.DataAnnotations;

namespace ERMAN.Dtos
{
    public class FAQItemDto
    {


        [Required(ErrorMessage = "FAQ question required.")]
        public string FAQQuestion { get; set; } = null!;

        [Required(ErrorMessage = "FAQ answer must be provided")]
        public string FAQAnswer { get; set; }

    }
}
