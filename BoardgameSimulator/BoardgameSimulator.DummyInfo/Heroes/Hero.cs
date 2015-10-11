using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace BoardgameSimulator.DummyInfo.Heroes
{
    public class Hero
    {
        public Hero(string name, int uid, int sid)
        {
            this.Name = name;
            this.UnitId = uid;
            this.SkillId = sid;
        }

        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        public string Name { get; set; }

        public int UnitId { get; set; }

        public int SkillId { get; set; }
    }
}
