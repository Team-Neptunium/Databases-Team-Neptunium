using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace BoardgameSimulator.DummyModels.Items
{
    public class DummyItem : IDummyEntry
    {
        public DummyItem(string name, int dmgBonus, int hpBonus)
        {
            this.Name = name;
            this.DamageBonus = dmgBonus;
            this.HealthBonus = hpBonus;
            this.HeroId = null;
        }

        public DummyItem(string name, int dmgBonus, int hpBonus, int heroId)
        {
            this.Name = name;
            this.DamageBonus = dmgBonus;
            this.HealthBonus = hpBonus;
            this.HeroId = heroId;
        }

        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        public string Name { get; set; }

        public int DamageBonus { get; set; }
        
        public int HealthBonus { get; set; }

        public int? HeroId { get; set; }
    }
}
