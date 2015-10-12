using System;
using BoardgameSimulator.DummyInfo.AlignmentPerks;
using BoardgameSimulator.DummyInfo.Heroes;
using BoardgameSimulator.DummyInfo.Skills;
using BoardgameSimulator.DummyInfo.Units;
using MongoDB.Driver;

namespace BoardgameSimulator.MongoDB
{
    public static class DataSeeder
    {
        private static void DropTablesThenCreateThenSeed(MongoDatabase database)
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

            MongoCollection<Skill> skills = database.GetCollection<Skill>("skills");
            MongoCollection<Unit> units = database.GetCollection<Unit>("units");
            MongoCollection<AlignmentPerk> perks = database.GetCollection<AlignmentPerk>("perks");
            MongoCollection<Hero> heroes = database.GetCollection<Hero>("heroes");

            var skillsSeed = Skills.GenerateSkillsList();
            var unitsSeed = Units.GenerateUnitsList(200, 1234, 5, 20);
            var perksSeed = AlignmentPerks.GenerateAlignmentsList(200);
            var heroesSeed = Heroes.GenerateHeroesList(200);

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
