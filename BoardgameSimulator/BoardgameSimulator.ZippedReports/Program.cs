namespace BoardgameSimulator.ZippedReports
{
    using System;
    using System.IO;
    using System.IO.Compression;

    public class Program
    {
        public static void Main()
        {
            var rnd = new Random();
            var generator = new XlsReportGenerator();

            const string RootFolder = @"C:\Temp\DatabasesTeamworkBattlesReport";
            var workingDirectory = Path.Combine(RootFolder, "Working");

            var greatestWarStartDate = new DateTime(121, 3, 31);
            var currentDate = greatestWarStartDate;

            int daysWithBattlesCount = rnd.Next(1, 10);
            for (int i = 0; i < daysWithBattlesCount; i++)
            {
                currentDate = currentDate.AddDays(1 + rnd.NextDouble() * 3);
                string parsedDate = currentDate.ToString("dd-MMM-yyyy");
                string currentFolder = Path.Combine(workingDirectory, parsedDate);
                Directory.CreateDirectory(currentFolder);

                int battlesCount = rnd.Next(5, 10);
                for (int j = 1; j <= battlesCount; j++)
                {
                    generator.GenerateXls(currentFolder + "\\Battle-" + j);
                }
            }

            ZipFile.CreateFromDirectory(workingDirectory, RootFolder + "\\Battles.zip");

            Directory.Delete(workingDirectory, true);

            Console.WriteLine("Generating of battle reports completed!");
        }
    }
}