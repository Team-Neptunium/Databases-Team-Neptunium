﻿using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace BoardgameSimulator.DummyModels.Skills
{
    public class DummySkill : IDummyEntry
    {
        public DummySkill(string name, int dmg, int cd)
        {
            this.Name = name;
            this.Damage = dmg;
            this.Cooldown = cd;
        }

        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        public string Name { get; set; }

        public int Damage { get; set; }

        public int Cooldown { get; set; }
    }
}
