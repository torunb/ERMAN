using System.ComponentModel.DataAnnotations;

namespace ERMAN.Models
{
    public class ErasmusOffice
    {
        [Key]
        public int Id { get; set; }

        public string? Email { get; set; }

        public string? FirstName { get; set; }

        public string? LastName { get; set; }
    }
}
