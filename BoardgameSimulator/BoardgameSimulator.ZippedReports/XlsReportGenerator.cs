namespace BoardgameSimulator.ZippedReports
{
    using System;
    using System.IO;
    using System.Reflection;
    using System.Runtime.InteropServices;
    using Microsoft.Office.Interop.Excel;

    public class XlsReportGenerator
    {
        private const string HeroId = "HeroID";
        private const string UnitsId = "UnitsID";
        private const string UnitsQuantity = "Units Quantity";

        private const string AlignmentFolderName = "AlignmentID-";
        private const string ReportFileName = "Report-";

        private readonly Random rnd = new Random();

        /// <summary>
        /// Generates Excel reports for the armies of the alignments.
        /// Each alignment has a separate folder named AlignmentID-X where X is the alignment id.
        /// In each folder there are random number of reports.
        /// Each report has a random number of lines giving information for each army of the alignment.
        /// </summary>
        /// <param name="alignmentCount">The count of alignments</param>
        /// <param name="minReportsCountPerAlignment">The minimum number of filereports you want per alignment</param>
        /// <param name="maxReportsCountPerAlignment">The maximum number of filereports you want per alignment</param>
        /// <param name="minArmiesPerAlignmentCount">The minimum number of lines (armies) in a single filereport</param>
        /// <param name="maxArmiesPerAlignmentCount">The maximum number of lines (armies) in a single filereport</param>
        /// <param name="rootDirectory">The directory into which all AlignmentID-X directories will be created.</param>
        public void GenerateXlsAlignmentsReports(
            int alignmentCount,
            int minReportsCountPerAlignment,
            int maxReportsCountPerAlignment,
            int minArmiesPerAlignmentCount,
            int maxArmiesPerAlignmentCount,
            string rootDirectory)
        {
            var app = new Application { Visible = false };
            var workbooks = app.Workbooks;
            var workbook = workbooks.Add(Missing.Value);
            Worksheet worksheet = workbook.ActiveSheet;

            // Populate first row
            worksheet.Cells[1, 1] = HeroId;
            worksheet.Cells[1, 2] = UnitsId;
            worksheet.Cells[1, 3] = UnitsQuantity;

            for (int currentAlignment = 1; currentAlignment <= alignmentCount; currentAlignment++)
            {
                string currentFolder = Path.Combine(rootDirectory, AlignmentFolderName + currentAlignment);
                Directory.CreateDirectory(currentFolder);

                this.SaveReports(
                    minReportsCountPerAlignment,
                    maxReportsCountPerAlignment,
                    minArmiesPerAlignmentCount,
                    maxArmiesPerAlignmentCount,
                    worksheet,
                    workbook,
                    currentFolder);
            }

            // Save and Release COM objects
            Marshal.ReleaseComObject(worksheet);
            workbook.Close(true);
            Marshal.ReleaseComObject(workbook);
            Marshal.ReleaseComObject(workbooks);
            app.Quit();
            Marshal.ReleaseComObject(app);
        }

        private void SaveReports(
            int minReportsCountPerAlignment,
            int maxReportsCountPerAlignment,
            int minArmiesPerAlignmentCount,
            int maxArmiesPerAlignmentCount,
            Worksheet worksheet,
            Workbook workbook,
            string currentFolder)
        {
            int reportsCount = this.rnd.Next(minReportsCountPerAlignment, maxReportsCountPerAlignment + 1);
            for (int currentReport = 1; currentReport <= reportsCount; currentReport++)
            {
                int armiesCount = this.rnd.Next(minArmiesPerAlignmentCount, maxArmiesPerAlignmentCount + 1);
                for (int currentArmy = 2; currentArmy < armiesCount + 2; currentArmy++)
                {
                    // TODO: Get this hardcoded values from some Constants class when available.
                    worksheet.Cells[currentArmy, 1] = this.rnd.Next(1, 201);
                    worksheet.Cells[currentArmy, 2] = this.rnd.Next(1, 201);
                    worksheet.Cells[currentArmy, 3] = this.rnd.Next(1, 1001) * 10;
                }

                workbook.SaveAs(Path.Combine(currentFolder, ReportFileName + currentReport));

                for (int currentArmy = 2; currentArmy < armiesCount + 2; currentArmy++)
                {
                    worksheet.Cells[currentArmy, 1] = null;
                    worksheet.Cells[currentArmy, 2] = null;
                    worksheet.Cells[currentArmy, 3] = null;
                }
            }
        }
    }
}