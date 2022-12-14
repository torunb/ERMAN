﻿using ERMAN.Models;

namespace ERMAN.Dtos
{
    public class PlacementStudentDto
    {
        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        public string? StudentId { get; set; }

        public string? Faculty { get; set; }

        public string? Department { get; set; }

        public string? Degree { get; set; }

        public string? TotalPoints { get; set; }

        public string? DurationPreferred { get; set; }

        public int? Ranking { get; set; }

        public University? University { get; set; }

        public List<University> PreferredUniversity { get; set; } = new List<University>();
    }
}
