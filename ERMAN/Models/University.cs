using System.ComponentModel.DataAnnotations;

namespace ERMAN.Models
{
    public class University
    {
        [Key]
        public int Id { get; set; }

        public string UniversityName { get; set; } = null!;

        public int UniversityCapacity { get; set; }

        public DateTime InsertDate { get; set; } = DateTime.Now;
    }
}
