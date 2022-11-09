﻿using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace ERMAN.Models
{
    public class Student
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(8)]
        public int StudentId { get; set; }

        [Required]  
        [StringLength(100)]
        public string StudentName { get; set; } = null!;

        [Required]
        [StringLength(360)]
        [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "Please enter valid e-mail address")]
        public string StudentEmailAddress { get; set; } = null!;
    }
}
