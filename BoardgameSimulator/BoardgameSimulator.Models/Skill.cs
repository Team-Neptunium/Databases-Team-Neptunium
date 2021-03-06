﻿namespace BoardgameSimulator.Models
{
    using System.ComponentModel.DataAnnotations;

    public class Skill
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [Required]
        public int Damage { get; set; }

        [Required]
        public int Cooldown { get; set; }
    }
}
