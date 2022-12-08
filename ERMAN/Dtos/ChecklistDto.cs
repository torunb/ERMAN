using System.ComponentModel.DataAnnotations;


namespace ERMAN.Dtos
{
    public class ChecklistDto
    {
        [Required(ErrorMessage = "User Id required.")]
        public int UserId { get; set; }


        [Required(ErrorMessage = "checked required.")]
        public bool[] Checked { get; set; }
    }
}
