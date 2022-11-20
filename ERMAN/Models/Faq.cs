using System.ComponentModel.DataAnnotations;

namespace ERMAN.Models
{
    public class Faq
    {
        [Key]
        public int Id { get; set; }

        public string Question { get; set; } = null!;

        public string Answer { get; set; } = null!;

        public DateTime InsertDate { get; set; } = DateTime.Now;
    }
}
