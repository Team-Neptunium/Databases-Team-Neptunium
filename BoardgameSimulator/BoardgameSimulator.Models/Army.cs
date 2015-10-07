using System;

namespace BoardgameSimulator.Models
{
    public class Army
    {
        public int Id { get; set; }

        public int AlignemntPerksId { get; set; }

        public virtual AlignmentPerk AlignmentPerks { get; set; }

        public Guid HeroId { get; set; }

        public virtual Hero Hero { get; set; }

        public int UnitsId { get; set; }

        public virtual Unit Units { get; set; }

        public int UnitQuantity { get; set; }
    }
}
