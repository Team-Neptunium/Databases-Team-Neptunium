namespace BoardgameSimulator.ZippedReports
{
    using System.IO;
    using System.IO.Compression;

    public class Program
    {
        public static void Main()
        {
            const string RootDirectory = @"C:\Temp\DatabasesTeamworkReports";
            const string ZipFilename = "AlignmentsReports.zip";
            string workingDirectory = Path.Combine(RootDirectory, "Working");

            var generator = new XlsReportGenerator();
            generator.GenerateXlsAlignmentsReports(200, 1, 3, 1, 3, workingDirectory);

            ZipFile.CreateFromDirectory(workingDirectory, Path.Combine(RootDirectory, ZipFilename));

            Directory.Delete(workingDirectory, true);
        }
    }
}