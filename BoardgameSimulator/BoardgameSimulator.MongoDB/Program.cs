using System;
using MongoDB.Bson;
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
            MongoClient client = new MongoClient(connectionString);

            var database = client.GetDatabase("boardgamesimulatormongodb");
            var employees = database.GetCollection<Unit>("units");    // "emp" is the collection name
            var peshos = database.GetCollection<Pesho>("peshos");

            // peshos.InsertOneAsync(new Pesho { PeshoStr = "Popooooko" });
            // peshos.InsertOneAsync(new Pesho { PeshoStr = "we hate" });

            // employees.InsertOneAsync(new Unit { Name = "Gosho" });

            Console.ReadLine();

            //var query = Query<EmpInfo>.EQ(e => e.empName, "Tom");

            var we = peshos.FindAsync(p => p.PeshoStr == "slsbsls").ToJson();

           //peshos.FindAsync()
            Console.WriteLine(list);
        }
    }

    public class Unit
    {
        public string Name { get; set; }
    }

    public class Pesho
    {
        public string PeshoStr { get; set; }
    }
}
