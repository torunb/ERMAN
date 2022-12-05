using System.ComponentModel.DataAnnotations;

namespace ERMAN.Models
{
    public class ToDo
    {
        [Key]
        public int Id { get; set; }

        public string UserType { get; set; } = null!;

        public string Text { get; set; } = null!;

        public string Type { get; set; } = null!;

        public bool Starred { get; set; }

        public string DueDate { get; set; } = null!;

        public bool Done { get; set; }

        public DateTime InsertDate { get; set; } = DateTime.Now;
    }
}
