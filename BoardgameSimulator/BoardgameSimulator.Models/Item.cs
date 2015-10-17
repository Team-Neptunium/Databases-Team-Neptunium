namespace BoardgameSimulator.Models
{
    using System.ComponentModel.DataAnnotations;

    public class Item
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(75)]
        public string Name { get; set; }

        [Required]
        public int DamageBonus { get; set; }

        [Required]
        public int HealthBonus { get; set; }
    }
}
