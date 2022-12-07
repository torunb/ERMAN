using System.ComponentModel.DataAnnotations;


namespace ERMAN.Dtos
{
    public class ChecklistDto
    {
        [Required(ErrorMessage = "User Id required.")]
        public int UserId { get; set; }

        [Required(ErrorMessage = "Text field required.")]
        public string Text { get; set; } = null!;

        public bool Checked { get; set; }
    }
}
