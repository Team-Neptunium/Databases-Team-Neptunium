namespace BoardgameSimulator.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Item
    {
        private ICollection<Hero> heroes;

        public Item()
        {
            this.heroes = new HashSet<Hero>();
        }

        public int Id { get; set; }

        [Required]
        [MaxLength(75)]
        public string Name { get; set; }

        [Required]
        public int DamageBonus { get; set; }

        [Required]
        public int HealthBonus { get; set; }

        public virtual ICollection<Hero> Heroes
        {
            get { return this.heroes; }
            set { this.heroes = value; }
        }
    }
}
