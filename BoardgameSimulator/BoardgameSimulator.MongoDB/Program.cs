using System;
using BoardgameSimulator.DummyInfo.AlignmentPerks;
using BoardgameSimulator.DummyInfo.Heroes;
using BoardgameSimulator.DummyInfo.Skills;
using BoardgameSimulator.DummyInfo.Units;
using MongoDB.Driver;

namespace BoardgameSimulator.MongoDB
{
    class Program
    {
        public static void Main()
        {
            const string dbName = "boardgamesimulatormongodb";
            Console.Write("Enter your {0} username: ", dbName);
            var uname = Console.ReadLine().Trim();
            Console.Write("Enter your {0} password: ", dbName);
            var pw = Console.ReadLine().Trim();

            //var connectionString = "mongodb://localhost:27017";
            var connectionString = string.Format("mongodb://{0}:{1}@ds033734.mongolab.com:33734/{2}", uname, pw, dbName);

            try
            {
                MongoClient client = new MongoClient(connectionString);
                MongoServer server = client.GetServer();
                MongoDatabase database = server.GetDatabase(dbName);

                MongoCollection<Skill> skills = database.GetCollection<Skill>("skills");
                MongoCollection<Unit> units = database.GetCollection<Unit>("units");
                MongoCollection<AlignmentPerk> perks = database.GetCollection<AlignmentPerk>("perks");
                MongoCollection<Hero> heroes = database.GetCollection<Hero>("heroes");
            }
            catch (FormatException)
            {
                Console.WriteLine(
                    "You must enter your username and password that have been provided to you by the dbadmin!");
            }
            catch (Exception)
            {
                Console.WriteLine("An error occured while attempting to connect to MongoDB @{0}, possible solutions: " +
                                  "\nCheck your credentials and try again." +
                                  "\nContact dbadmin for new credentials." +
                                  "\nCheck if server is online and running and try again.", dbName);
            }
        }

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
            var unitsSeed = Units.GenerateUnitsList(200);
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
