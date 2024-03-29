﻿using ERMAN.Dtos;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace ERMAN.Models
{
    public class Student
    {
        [Key]
        public int Id { get; set; }

        [StringLength(360)]
        [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "Please enter valid e-mail address")]
        public string? Email { get; set; } = null!;

        public int AuthId { get; set; }

        public int? CoordinatorId { get; set; }

        public string? CoordinatorName { get; set; }
        public string? UniversityName { get; set; }
        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        public string? Department { get; set; }

        public string? Faculty { get; set; }

        public int Ranking { get; set; } = 0!;

        public string? ApplicationStatus { get; set; }

        public virtual University? University { get; set; }

        [Required]
        public int StudentId { get; set; }

        public bool IsRejected { get; set; }

        public string? DurationPreffered { get; set; }

        public AppliedProgram? Program { get; set; }

        public virtual List<University> UniversityPreference { get; set; } = new List<University>();

        public virtual List<Course> Courses { get; set; } = new List<Course>();

        public virtual List<CourseMapped> SelectedCourses { get; set; } = new List<CourseMapped>();

        public virtual List<Message> Messages { get; set; } = new List<Message>();

        public DateTime InsertDate { get; set; } = DateTime.Now;

        public double TotalPoints { get; set; }

        public string? Degree { get; set; }
    }
}

public enum AppliedProgram
{
    Erasmus,
    Exchange
}
