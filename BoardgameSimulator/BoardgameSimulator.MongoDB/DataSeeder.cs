using System;
using BoardgameSimulator.DummyModels.AlignmentPerks;
using BoardgameSimulator.DummyModels.Heroes;
using BoardgameSimulator.DummyModels.Skills;
using BoardgameSimulator.DummyModels.Units;
using MongoDB.Driver;

namespace BoardgameSimulator.MongoDB
{
    public static class DataSeeder
    {
        public static void DropTablesThenCreateThenSeed(MongoDatabase database)
        {
            Console.WriteLine("Are you SURE you wish to DROP the 'skills', 'units', 'perks', and 'heroes' collections?");
            Console.Write("y/n: ");
            var response = (char)Console.Read();

            if (!(response == 'y' || response == '\r'))
            {
                return;
            }

            database.DropCollection("skills");
            Console.WriteLine("Skills collection dropped.");
            database.DropCollection("units");
            Console.WriteLine("Units collection dropped.");
            database.DropCollection("perks");
            Console.WriteLine("Perks collection dropped.");
            database.DropCollection("heroes");
            Console.WriteLine("Heroes collection dropped.");

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
            Console.WriteLine("{0} Skill entries seeded successfully!", d);
            d = unitsSeed.Count;
            units.InsertBatch(unitsSeed);
            Console.WriteLine("{0} Unit entries seeded successfully!", d);
            d = perksSeed.Count;
            perks.InsertBatch(perksSeed);
            Console.WriteLine("{0} Perk entries seeded successfully!", d);
            d = heroesSeed.Count;
            heroes.InsertBatch(heroesSeed);
            Console.WriteLine("{0} Hero entries seeded successfully!", d);

            Console.WriteLine("Seeding completed!");
        }
    }
}
