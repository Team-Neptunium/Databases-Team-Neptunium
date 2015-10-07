using System.Collections.Generic;

namespace BoardgameSimulator.Models
{
    public class Item
    {
        private ICollection<Hero> heroes;

        public Item()
        {
            this.heroes = new HashSet<Hero>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public int DamageBonus { get; set; }

        public int HealthBonus { get; set; }

        public virtual ICollection<Hero> Heroes
        {
            get { return this.heroes; }
            set { this.heroes = value; }
        }
    }
}
