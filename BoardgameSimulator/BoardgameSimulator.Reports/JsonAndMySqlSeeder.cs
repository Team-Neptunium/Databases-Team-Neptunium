namespace BoardgameSimulator.Reports
{
    using System.Linq;
    using Data;
    using MySqlDB;

    public class JsonAndMySqlSeeder
    {
        public static void Seed(BoardgameSimulatorMySqlData mySqlData, BoardgameSimulatorData sqlData)
        {
            var blog = sqlData.BattleLogs.All().Select(x => new {}).ToList();

            var jsonGen = new JsonGenerator();



        }

    }
}
