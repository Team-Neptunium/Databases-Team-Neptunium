namespace BoardgameSimulator.Reports
{
    using System;
    using System.Linq;
    using Data;
    using MySqlDB;
    using MySqlDB.Models;

    public class JsonAndMySqlSeeder
    {
        public static void Seed(BoardgameSimulatorMySqlData mySqlData, BoardgameSimulatorData sqlData)
        {
            var bLog = sqlData.BattleLogs.All().Select(x => new ArmyVsArmyReport
            {
                Army1Id = x.Army1Id,
                UnitName1 = x.Army1.Unit.Name,
                UnitQuantity1 = x.Army1.UnitQuantity,
                Army2Id = x.Army2Id,
                UnitName2 = x.Army2.Unit.Name,
                UnitQuantity2 = x.Army2.UnitQuantity,
                Date = x.Date
            }).ToList();

            Console.WriteLine("Seeding of BattleLog entries into MySql Db initialized.");
            mySqlData.ArmyVsArmyReports.DeleteAllReports();
            mySqlData.ArmyVsArmyReports.AddMany(bLog);
            mySqlData.ArmyVsArmyReports.SaveChanges();
            Console.WriteLine("Seeding of BattleLog entries completed!");

            var jsonGen = new JsonGenerator();

            Console.WriteLine("Adding BattleLog entries to Json files initialized.");
            foreach (var log in bLog)
            {
                jsonGen.CreateJsonArmy(log);
            }

            Console.WriteLine("Adding BattleLog entries completed!");
        }
    }
}
