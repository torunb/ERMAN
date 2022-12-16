using System.ComponentModel.DataAnnotations;

namespace ERMAN.Models
{
    public class PlacementStudent
    {
        [Key]
        public int Id { get; set; }

        public string? FirstName { get; set; }

        public string? LastName { get; set; }   

        public string? StudentId { get; set; }

        public string? Faculty { get; set; }

        public string? Department { get; set; }

        public string? Degree { get; set; }

        public string? TotalPoints { get; set; }

        public string? DurationPreferred { get; set; }

        public int? Ranking { get; set; }

        public int? UniversityId { get; set; }

        public List<string> PreferredUniversity { get; set; } = new List<string>();
    }
}
