using System.ComponentModel.DataAnnotations.Schema;

namespace BoardgameSimulator.Models
{
    using System.ComponentModel.DataAnnotations;

    public class Unit
    {
        [Key]
        [Column("Id")]
        public int UnitId { get; set; }

        [Required]
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
