using MongoDB.Driver;

namespace BoardgameSimulator.MongoDB
{
    using System;
    using DummyModels.AlignmentPerks;
    using DummyModels.Heroes;
    using DummyModels.Skills;
    using DummyModels.Units;

    public class MongoDbDataSeeder
    {
        private const string DropCollectionMessage = "{0} collection dropped.";
        private const string SeedMessage = "{0} {1} entries seeded successfully into the MongoDb!";

        public static void Seed()
        {
            var mongoConnection = new MongoConnection();

            mongoConnection.Connect("boardgamesimulatormongodb");

            var database = mongoConnection.Database;

            database.DropCollection("skills");
            Console.WriteLine(DropCollectionMessage, "skills");
            database.DropCollection("units");
            Console.WriteLine(DropCollectionMessage, "units");
            database.DropCollection("perks");
            Console.WriteLine(DropCollectionMessage, "perks");
            database.DropCollection("heroes");
            Console.WriteLine(DropCollectionMessage, "heroes");

            MongoCollection<DummySkill> skills = database.GetCollection<DummySkill>("skills");
            MongoCollection<DummyUnit> units = database.GetCollection<DummyUnit>("units");
            MongoCollection<DummyAlignmentPerk> perks = database.GetCollection<DummyAlignmentPerk>("perks");
            MongoCollection<DummyHero> heroes = database.GetCollection<DummyHero>("heroes");

            var skillsSeed = DummySkills.GenerateSkillsList();
            var unitsSeed = Units.GenerateUnitsList(200, 1234, 5, 20);
            var perksSeed = DummyAlignmentPerks.GenerateAlignmentsList(200);
            var heroesSeed = DummyHeroes.GenerateHeroesList(200);

            var d = skillsSeed.Count;

            skills.InsertBatch(skillsSeed);
            Console.WriteLine(SeedMessage, d, "Skill");
            d = unitsSeed.Count;
            units.InsertBatch(unitsSeed);
            Console.WriteLine(SeedMessage, d, "Unit");
            d = perksSeed.Count;
            perks.InsertBatch(perksSeed);
            Console.WriteLine(SeedMessage, d, "Perk");
            d = heroesSeed.Count;
            heroes.InsertBatch(heroesSeed);
            Console.WriteLine(SeedMessage, d, "Hero");

            Console.WriteLine("Seeding of MongoDb completed!");
        }
    }
}
