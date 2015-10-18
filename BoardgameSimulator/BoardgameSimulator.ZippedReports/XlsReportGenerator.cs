namespace BoardgameSimulator.ZippedReports
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.IO.Compression;
    using System.Reflection;
    using System.Runtime.InteropServices;

    using Microsoft.Office.Interop.Excel;

    public class XlsReportGenerator : IDisposable
    {
        private const string AlignmentFolderName = "AlignmentPerkId-";
        private const string ReportFileName = "Report-";

        private const int StartRow = 2;
        private static readonly string[] FirstRowInSheet = { "HeroId", "UnitId", "UnitQuantity" };

        private readonly Random rnd;

        private readonly Application app;
        private readonly Workbook workbook;
        private readonly Workbooks workbooks;
        private readonly Worksheet worksheet;

        public XlsReportGenerator()
        {
            this.app = new Application { Visible = false };
            this.workbooks = this.app.Workbooks;
            this.workbook = this.workbooks.Add(Missing.Value);
            this.worksheet = this.workbook.ActiveSheet;
            this.worksheet.Name = "Sheet1";

            this.rnd = new Random();
        }

        ~XlsReportGenerator()
        {
            this.Dispose();
        }

        public void Dispose()
        {
            Marshal.ReleaseComObject(this.worksheet);
            this.workbook.Close(true);
            Marshal.ReleaseComObject(this.workbook);
            Marshal.ReleaseComObject(this.workbooks);
            this.app.Quit();
            Marshal.ReleaseComObject(this.app);

            GC.SuppressFinalize(this);
        }


        public static void GenerateArmiesInExcel2003(ushort uniqueAlignments = 50, string rootDirectory = @"C:\Temp\DatabasesTeamworkReports")
        {
            const string zipFilename = "ArmiesReports.zip";
            string workingDirectory = Path.Combine(rootDirectory, "Working");
            string zipFile = Path.Combine(rootDirectory, zipFilename);

            using (var generator = new XlsReportGenerator())
            {
                generator.GenerateXlsAlignmentsReports(uniqueAlignments, 1, 2, 1, 2, workingDirectory);
            }

            if (File.Exists(zipFile))
            {
                File.Delete(zipFile);
            }

            ZipFile.CreateFromDirectory(workingDirectory, zipFile);

            Directory.Delete(workingDirectory, true);
        }

        /// <summary>
        /// Generates Excel reports for the armies of the alignments.
        ///     Each alignment has a separate folder named AlignmentID-X where X is the alignment id.
        ///     In each folder there are random number of reports.
        ///     Each report has a random number of lines giving information for each army of the alignment.
        /// </summary>
        /// <param name="alignmentCount">
        /// The count of alignments
        /// </param>
        /// <param name="minReportsCountPerAlignment">
        /// The minimum number of filereports you want per alignment
        /// </param>
        /// <param name="maxReportsCountPerAlignment">
        /// The maximum number of filereports you want per alignment
        /// </param>
        /// <param name="minArmiesPerAlignmentCount">
        /// The minimum number of lines (armies) in a single filereport
        /// </param>
        /// <param name="maxArmiesPerAlignmentCount">
        /// The maximum number of lines (armies) in a single filereport
        /// </param>
        /// <param name="rootDirectory">
        /// The directory into which all AlignmentID-X directories will be created.
        /// </param>
        private void GenerateXlsAlignmentsReports(
            int alignmentCount, 
            int minReportsCountPerAlignment, 
            int maxReportsCountPerAlignment, 
            int minArmiesPerAlignmentCount, 
            int maxArmiesPerAlignmentCount, 
            string rootDirectory)
        {
            this.FillRow(1, FirstRowInSheet);

            if (Directory.Exists(rootDirectory))
            {
                Directory.Delete(rootDirectory, true);
            }

            var usedAlignments = new List<int>();

            Console.WriteLine("Generating of Xls reports into " + rootDirectory + " initialized.");

            for (int i = 1; i <= alignmentCount; i++)
            {
                var id = this.rnd.Next(1, 201);

                if (!usedAlignments.Contains(id))
                {
                    usedAlignments.Add(id);
                }
                else
                {
                    i--;
                    continue;
                }

                string currentFolder = Path.Combine(rootDirectory, AlignmentFolderName + id);
                Directory.CreateDirectory(currentFolder);

                int reportsCount = this.rnd.Next(minReportsCountPerAlignment, maxReportsCountPerAlignment + 1);
                this.SaveReports(reportsCount, currentFolder, minArmiesPerAlignmentCount, maxArmiesPerAlignmentCount);

                if (i%10 == 0)
                {
                    Console.WriteLine("Generating Xls reports" + new string('.', i/10));
                }
            }

            Console.WriteLine("Generated reports for " + alignmentCount + " alignments.");
        }

        private void SaveReports(
            int reportsCount, 
            string currentFolder, 
            int minArmiesPerAlignmentCount, 
            int maxArmiesPerAlignmentCount)
        {
            for (int currentReport = 1; currentReport <= reportsCount; currentReport++)
            {
                int rowsCount = this.rnd.Next(minArmiesPerAlignmentCount, maxArmiesPerAlignmentCount + 1);

                for (int currentRowNumber = StartRow; currentRowNumber < StartRow + rowsCount; currentRowNumber++)
                {
                    // TODO: Get this hardcoded values from some Constants class when available.
                    string heroId = this.rnd.Next(1, 201).ToString();
                    string unitsId = this.rnd.Next(1, 201).ToString();
                    string unitsQuantity = (this.rnd.Next(1, 1001) * 10).ToString();

                    this.FillRow(currentRowNumber, heroId, unitsId, unitsQuantity);
                }

                this.workbook.SaveAs(Path.Combine(currentFolder, ReportFileName + currentReport), XlFileFormat.xlWorkbookNormal);

                // Clean up the worksheet for the next iteration.
                for (int currentRowNumber = StartRow; currentRowNumber < StartRow + rowsCount; currentRowNumber++)
                {
                    this.FillRow(currentRowNumber, null, null, null);
                }
            }
        }

        private void FillRow(int row, params string[] cells)
        {
            for (int i = 0; i < cells.Length; i++)
            {
                this.worksheet.Cells[row, i + 1] = cells[i];
            }
        }
    }
}