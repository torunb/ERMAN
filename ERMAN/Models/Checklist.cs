﻿using System.ComponentModel.DataAnnotations;

namespace ERMAN.Models
{
    public class Checklist
    {
        [Key]
        public int Id { get; set; }

        public int UserId { get; set; }

        public string Text { get; set; } = null!;

        public bool Checked { get; set; }

    }
}
