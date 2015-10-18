namespace BoardgameSimulator.AdoNet
{
    public class Program
    {
        public static void Main()
        {
            const string ZippedArmiesReportsFilePath = @"C:\Temp\DatabasesTeamworkReports\ArmiesReports.zip";

            var armiesReportsSeeder = new ArmiesReportsSeeder();

            armiesReportsSeeder.SeedFromZip(ZippedArmiesReportsFilePath);
        }
    }
}
