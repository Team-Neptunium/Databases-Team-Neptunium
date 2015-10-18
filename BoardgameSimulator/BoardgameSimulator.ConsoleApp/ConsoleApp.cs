namespace BoardgameSimulator.ConsoleApp
{
    using System.Linq;
    using Data;
    using Models;
    using MongoDB;
    using Reports;
    using SQLiteDB;
    using XlsReader;
    using ZippedReports;

    public class ConsoleApp
    {
        public static void Main()   
        {
            var data = new BoardgameSimulatorData(new BoardgameSimulatorDbContext());

            /*
            var mongoConnection = new MongoConnection();
            mongoConnection.Connect();

            // Comment this line before starting the app, otherwise it will crash,
            // telling you that you have no rights to write into the MongoLab Db
            MongoDbDataSeeder.SeedToMongoDb(mongoConnection);

            MongoDbDataSeeder.SeedToSql(mongoConnection, data);

            XlsReportGenerator.GenerateArmiesInExcel2003();

            ArmiesReportsSeeder.SeedArmies();

            SqLiteDataSeeder.Seed();
            */
        }
    }
}
