using System.ComponentModel.DataAnnotations;

namespace ERMAN.Models
{
    public class Checklist
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "User Id required.")]
        public int UserId { get; set; }


        [Required(ErrorMessage = "checked required.")]
        public bool[] Checked { get; set; }

    }
}
