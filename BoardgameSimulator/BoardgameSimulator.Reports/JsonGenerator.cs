namespace BoardgameSimulator.Reports
{
    using System.IO;
    using MySqlDB.Models;
    using Newtonsoft.Json;

    public class JsonGenerator
    {
        private string workingDir = ".../.../.../Reports/Jsons";

        public JsonGenerator()
        {
            if (!Directory.Exists(workingDir))
            {
                Directory.CreateDirectory(workingDir);
            }
        }

        public void CreateJsonArmy(ArmyVsArmyReport report)
        {
            string json = JsonConvert.SerializeObject(report, Formatting.Indented);

            File.WriteAllText(Path.Combine(workingDir, (report.Army1Id + "-" + report.Army2Id + ".json")), json);
        }
    }
}