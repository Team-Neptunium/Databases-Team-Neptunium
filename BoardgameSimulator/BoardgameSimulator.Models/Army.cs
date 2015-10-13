namespace BoardgameSimulator.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Army
    {
        [Key]
        public int Id { get; set; }

        public string Name { get { return this.AlignmentPerk.Name + " of " + this.Unit.Name; } }

        public int AlignmentPerkId { get; set; }

        [ForeignKey("AlignmentPerkId")]
        public virtual AlignmentPerk AlignmentPerk { get; set; }

        public int HeroId { get; set; }

        [ForeignKey("HeroId")]
        public virtual Hero Hero { get; set; }

        public int UnitId { get; set; }

        [ForeignKey("UnitId")]
        public virtual Unit Unit { get; set; }

        [Required]
        public int UnitQuantity { get; set; }
    }
}
