namespace BoardgameSimulator.DummyModels.BattleLogs
{
    using System;
    using MongoDB.Bson;
    using MongoDB.Bson.Serialization.Attributes;

    public class DummyBattleLog : IDummyEntry
    {
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        public int Army1Id { get; set; }

        public int Army2Id { get; set; }

        public DateTime Date { get; set; }
    }
}
