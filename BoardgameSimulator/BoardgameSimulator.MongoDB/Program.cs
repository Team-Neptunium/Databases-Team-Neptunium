using System;
using BoardgameSimulator.DummyInfo.AlignmentPerks;
using BoardgameSimulator.DummyInfo.Heroes;
using BoardgameSimulator.DummyInfo.Skills;
using BoardgameSimulator.DummyInfo.Units;
using BoardgameSimulator.MongoDB.Data;
using MongoDB.Driver;

namespace BoardgameSimulator.MongoDB
{
    class Program
    {
        public static void Main()
        {
            const string dbName = "boardgamesimulatormongodb";
            
            var connection = new MongoConnection();

            connection.Connect(dbName);

            try
            {
                var skills = new GenericData<Skill>(connection.Database, "skills");
                var units = new GenericData<Unit>(connection.Database, "units");
                var perks = new GenericData<AlignmentPerk>(connection.Database, "perks");
                var heroes = new GenericData<Heroes>(connection.Database, "heroes");

                var skillsFromDb = skills.GetAllDataFromCollection();

                foreach (var skill in skillsFromDb)
                {
                    Console.WriteLine(skill.Name + " " + skill.Damage);
                }
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
                                  "\nCheck if server is online and running and try again." +
                                  "\nConnection may have timed out, check your query!", dbName);
            }
        }
    }
}
