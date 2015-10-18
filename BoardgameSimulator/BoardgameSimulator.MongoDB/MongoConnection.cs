using System;
using MongoDB.Driver;

namespace BoardgameSimulator.MongoDB
{
    public class MongoConnection
    {
        private const string ConnString = "mongodb://{0}:{1}@ds033734.mongolab.com:33734/{2}";

        private const string ConnStringLocal = "mongodb://localhost:27017";

        public MongoDatabase Database { get; private set; }

        public void Connect(string dbName)
        {
            Console.Write("Enter your {0} username: ", dbName);
            var uname = Console.ReadLine().Trim();

            Console.Write("Enter your {0} password: ", dbName);
            Console.ForegroundColor = Console.BackgroundColor;
            var pw = Console.ReadLine().Trim();
            Console.ResetColor();

            var client = new MongoClient(string.Format(ConnString, uname, pw, dbName));
            var server = client.GetServer();

            this.Database =  server.GetDatabase(dbName);
        }

        public void ConnectLocal(string dbName)
        {
            var client = new MongoClient(ConnStringLocal);
            var server = client.GetServer();

            this.Database = server.GetDatabase(dbName);
        }
    }
}
