using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace ERMAN.Dtos
{
    public class FAQItemDto : Controller
    {


        [Required(ErrorMessage = "FAQ question required.")]
        public string FAQQuestion { get; set; } = null!;

        [Required(ErrorMessage = "FAQ answer must be provided")]
        public int FAQAnswer { get; set; }

        public bool IsChecked { get; set; }

        [Required(ErrorMessage = "User id must be provided")]
        public int UserId { get; set; }
    }
}
