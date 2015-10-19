namespace BoardgameSimulator.ConsoleApp
{
    using Data;
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
            Demo();
        }

        /// <summary>
        /// It is imperative that the steps be executed in strict order, else errors and crashes may occur
        /// </summary>
        public static void Demo()
        {
            var data = new BoardgameSimulatorData(new BoardgameSimulatorDbContext());

            var mysql = new BoardgameSimulatorMySqlData();

            var mongoConnection = new MongoConnection();

            // Comment this line before starting the app, otherwise it will crash,
            // telling you that you have no rights to write into the MongoLab Db
            MongoDbDataSeeder.SeedToMongoDb(mongoConnection);

            // Feeds data from the MongoDb to SQL
            MongoDbDataSeeder.SeedToSql(mongoConnection, data);

            // Generates excel reports from which the db will later be seeded
            XlsReportGenerator.GenerateArmiesInExcel2003();

            // Feeds data from the excel reports into SQL
            ArmiesReportsSeeder.SeedArmies();

            // Feeds army vs army data from the MongoDb to SQL
            MongoDbDataSeeder.SeedBattleLogsToSql(mongoConnection, data);

            // Seeds the SqLiteDb with additional data about units
            SqLiteDataSeeder.Seed();

            // Additional data is exported from SQL into json files and into the MySQLDb
            JsonAndMySqlSeeder.Seed(mysql, data);

            var pdfGen = new PdfGenerator();
            pdfGen.CreatePerksGroupArmyReport(data.Armies.All());
            pdfGen.CreatePdfSkillsPotentialReport(data.Skills.All());

            var sqlite = new BoardgameSimulatorSqLiteData();

            var armyVs = mysql.ArmyVsArmyReports.All();
            var armyE = sqlite.UnitsCosts.All();

            new ExcelGenerator().CreateBattleLogExcelReport(armyVs, armyE);

            XmlImporter.ImportToSqlAndMongo(data, mongoConnection);

            new XmlGenerator().CreateHeroesReport(data.Heroes.All());
        }
    }
}
