namespace BoardgameSimulator.ConsoleApp
{
    using System.Linq;
    using Data;
    using Models;
    using MongoDB;
    using MySqlDB;
    using Reports;
    using SQLiteDB;
    using XlsReader;
    using ZippedReports;
    using Importer;

    public class ConsoleApp
    {
        public static void Main()
        {
            var data = new BoardgameSimulatorData(new BoardgameSimulatorDbContext());

            /* 
            var mysql = new BoardgameSimulatorMySqlData();           
            var mongoConnection = new MongoConnection();
            mongoConnection.Connect();

            // Comment this line before starting the app, otherwise it will crash,
            // telling you that you have no rights to write into the MongoLab Db
            MongoDbDataSeeder.SeedToMongoDb(mongoConnection);

            MongoDbDataSeeder.SeedToSql(mongoConnection, data);

            XlsReportGenerator.GenerateArmiesInExcel2003();

            ArmiesReportsSeeder.SeedArmies();

            MongoDbDataSeeder.SeedBattleLogsToSql(mongoConnection, data);

            SqLiteDataSeeder.Seed();
            
            JsonAndMySqlSeeder.Seed(mysql, data);
            */
        }
    }
}
