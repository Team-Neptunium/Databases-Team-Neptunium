namespace BoardgameSimulator.ConsoleApp
{
    using System;
    using System.Linq;
    using Data;
    using Models;
    using MongoDB;
    using MySqlDB;
    using Reports;
    using SQLiteDB;
    using XlsReader;
    using ZippedReports;
    using XmlImporter;

    public class ConsoleApp
    {
        public static void Main()
        {
            var data = new BoardgameSimulatorData(new BoardgameSimulatorDbContext());

            // var mysql = new BoardgameSimulatorMySqlData();

            var mongoConnection = new MongoConnection();

            /*

            // Comment this line before starting the app, otherwise it will crash,
            // telling you that you have no rights to write into the MongoLab Db
            MongoDbDataSeeder.SeedToMongoDb(mongoConnection);

            MongoDbDataSeeder.SeedToSql(mongoConnection, data);

            XlsReportGenerator.GenerateArmiesInExcel2003();

            ArmiesReportsSeeder.SeedArmies();

            MongoDbDataSeeder.SeedBattleLogsToSql(mongoConnection, data);

            SqLiteDataSeeder.Seed();
            
            JsonAndMySqlSeeder.Seed(mysql, data);

            var pdfGen = new PdfGenerator();
            pdfGen.CreatePerksGroupArmyReport(data.Armies.All());
            pdfGen.CreatePdfSkillsPotentialReport(data.Skills.All());

            var sqlite = new BoardgameSimulatorSqLiteData();

            var armyVs = mysql.ArmyVsArmyReports.All();
            var armyE = sqlite.UnitsCosts.All();

            new ExcelGenerator().CreateBattleLogExcelReport(armyVs, armyE);
            */

            XmlImporter.ImportToSqlAndMongo(data, mongoConnection);

            new XmlGenerator().CreateHeroesReport(data.Heroes.All());
        }
    }
}
