namespace BoardgameSimulator.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Unit
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        public AttackType AttackType { get; set; }

        [Required]
        public int Damage { get; set; }

        [Required]
        public double AttackRate { get; set; }

        [Required]
        public int Health { get; set; }
    }
}
