using System.ComponentModel.DataAnnotations;

namespace ERMAN.Models
{
    public class StudentPlacement
    {
        [Key]
        public int PlacementId { get; set; }
        [Required(ErrorMessage = "Student must be specified")]
        public long StudentId { get; set; }
        public string StudentFirstName { get; set; }
        public string StudentLastName { get; set; }
        public string Faculty { get; set; }
        public string Department { get; set; }
        public string Degree { get; set; } 
        public double TranscriptGradeFromFour { get; set; }
        public double TranscriptGradeFromHundred { get; set; }
        public double TranscriptGradeContribution { get; set; }

        public double ErasmusApplicationWithGradesBehindSeUe { get; set; }
        public int UESECount { get; set; }
        public double UECGPA { get; set; }

        public string Eng101 { get; set; }
        public string Eng102 { get; set; }

        public double LanguagePoints { get; set; }
        public double TranscriptPoints { get; set; }

        public double TotalPoints { get; set; } // score
        public string DurationPrefered { get; set; }


        [Required(ErrorMessage = "University preferences must be specified")]
        public string[] UniversityChoices { get; set; } // Preffered university no, uni name
        public bool IsInWaitingList { get; set; }

        //public int OverallPlacement { get; set; } seems unnecessary
        //public string Department { get; set; }
        //date may be added...

    }
}
