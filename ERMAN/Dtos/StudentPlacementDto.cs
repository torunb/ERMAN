using System.ComponentModel.DataAnnotations;


namespace ERMAN.Dtos
{
    public class StudentPlacementDto
    {
        [Required(ErrorMessage = "Student must be specified")]
        public long StudentId { get; set; }
        public string StudentFirstName { get; set; }
        public string StudentLastName { get; set; }

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
    }
}
