namespace BoardgameSimulator.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Item
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [Required]
        public int DamageBonus { get; set; }

        [Required]
        public int HealthBonus { get; set; }

        public int? HeroId { get; set; }

        [ForeignKey("HeroId")]
        public virtual Hero Hero { get; set; }
    }
}
