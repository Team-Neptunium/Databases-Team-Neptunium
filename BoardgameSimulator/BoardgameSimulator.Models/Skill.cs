namespace BoardgameSimulator.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Skill
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public int Damage { get; set; }

        [Required]
        public int Cooldown { get; set; }
    }
}
