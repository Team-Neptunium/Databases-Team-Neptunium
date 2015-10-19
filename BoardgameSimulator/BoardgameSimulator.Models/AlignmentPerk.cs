namespace BoardgameSimulator.Models
{
    using System.ComponentModel.DataAnnotations;

    public class AlignmentPerk
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        public string Type { get; set; }

        [Required]
        public double HealthMultiplier { get; set; }

        [Required]
        public double DamageMultiplier { get; set; }
    }
}
