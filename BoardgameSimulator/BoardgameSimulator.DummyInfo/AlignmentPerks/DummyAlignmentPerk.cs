using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace BoardgameSimulator.DummyInfo.AlignmentPerks
{
    public class DummyAlignmentPerk
    {
        public DummyAlignmentPerk(string name, string type, double dmg, double hp)
        {
            this.Name = name;
            this.Type = type;
            this.DamageModifier = dmg;
            this.HealthModifier = hp;
        }

        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        public string Name { get; set; }

        public string Type { get; set; }

        public double DamageModifier { get; set; }

        public double HealthModifier { get; set; }
    }
}
