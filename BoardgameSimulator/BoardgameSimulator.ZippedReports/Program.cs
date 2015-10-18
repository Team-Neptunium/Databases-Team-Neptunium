namespace BoardgameSimulator.ZippedReports
{
    using System.IO;
    using System.IO.Compression;

    public class Program
    {
        public static void Main()
        {
            const string RootDirectory = @"C:\Temp\DatabasesTeamworkReports";
            const string ZipFilename = "ArmiesReports.zip";
            string workingDirectory = Path.Combine(RootDirectory, "Working");

            using (var generator = new XlsReportGenerator())
            {
                generator.GenerateXlsAlignmentsReports(100, 1, 2, 1, 2, workingDirectory);
            }

            ZipFile.CreateFromDirectory(workingDirectory, Path.Combine(RootDirectory, ZipFilename));

            Directory.Delete(workingDirectory, true);
        }
    }
}