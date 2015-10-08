using System.ComponentModel.DataAnnotations;

namespace BoardgameSimulator.Models
{
    public class AlignmentPerk
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        public string Type { get; set; }

        [Required]
        public double HealthMultiplier { get; set; }

        [Required]
        public double DamageMultiplier { get; set; }
    }
}
