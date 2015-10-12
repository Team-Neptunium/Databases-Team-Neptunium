using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace BoardgameSimulator.DummyModels.Units
{
    public class DummyUnit : IDummyEntry
    {
        public DummyUnit(string name, int type, int damage, double rate, int hp)
        {
            this.Name = name;
            this.AttackType = type;
            this.Damage = damage;
            this.AttackRate = rate;
            this.Health = hp;
        }

        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        public string Name { get; set; }

        public int AttackType { get; set; }

        public int Damage { get; set; }

        public double AttackRate { get; set; }

        public int Health { get; set; }
    }
}
