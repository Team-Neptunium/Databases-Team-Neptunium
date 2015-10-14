namespace BoardgameSimulator.ZippedReports
{
    using System;
    using System.IO;
    using System.Reflection;
    using System.Runtime.InteropServices;
    using Microsoft.Office.Interop.Excel;

    public class XlsReportGenerator : IDisposable
    {
        private const string HeroId = "HeroID";
        private const string UnitsId = "UnitsID";
        private const string UnitsQuantity = "Units Quantity";

        private const string AlignmentFolderName = "AlignmentID-";
        private const string ReportFileName = "Report-";

        private readonly Application app;
        private readonly Workbooks workbooks;
        private readonly Workbook workbook;
        private readonly Worksheet worksheet;

        private readonly Random rnd;

        public XlsReportGenerator()
        {
            this.app = new Application { Visible = false };
            this.workbooks = this.app.Workbooks;
            this.workbook = this.workbooks.Add(Missing.Value);
            this.worksheet = this.workbook.ActiveSheet;

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
            this.FillFirtsRowWithTitles(HeroId, UnitsId, UnitsQuantity);

            for (int currentAlignment = 1; currentAlignment <= alignmentCount; currentAlignment++)
            {
                string currentFolder = Path.Combine(rootDirectory, AlignmentFolderName + currentAlignment);
                Directory.CreateDirectory(currentFolder);

                int reportsCount = this.rnd.Next(minReportsCountPerAlignment, maxReportsCountPerAlignment + 1);
                this.SaveReports(reportsCount, currentFolder, minArmiesPerAlignmentCount, maxArmiesPerAlignmentCount);
            }
        }

        private void FillFirtsRowWithTitles(params string[] titles)
        {
            for (int i = 0; i < titles.Length; i++)
            {
                this.worksheet.Cells[1, i + 1] = titles[i];
            }
        }

        private void SaveReports(int reportsCount, string currentFolder, int minArmiesPerAlignmentCount, int maxArmiesPerAlignmentCount)
        {
            for (int currentReport = 1; currentReport <= reportsCount; currentReport++)
            {
                int rowsCount = this.rnd.Next(minArmiesPerAlignmentCount, maxArmiesPerAlignmentCount + 1);

                this.WriteDataInWorksheet(2, rowsCount);

                this.workbook.SaveAs(Path.Combine(currentFolder, ReportFileName + currentReport));

                this.CleanUpDataFromWorksheet(2, rowsCount);
            }
        }

        private void WriteDataInWorksheet(int startingRow, int rowsCount)
        {
            for (int currentRow = startingRow; currentRow < startingRow + rowsCount; currentRow++)
            {
                // TODO: Get this hardcoded values from some Constants class when available.
                // Write Hero ID
                this.worksheet.Cells[currentRow, 1] = this.rnd.Next(1, 201);

                // Write Units ID
                this.worksheet.Cells[currentRow, 2] = this.rnd.Next(1, 201);

                // Write Units Quantity
                this.worksheet.Cells[currentRow, 3] = this.rnd.Next(1, 1001) * 10;
            }
        }

        private void CleanUpDataFromWorksheet(int startingRow, int rowsCount)
        {
            for (int currentRow = startingRow; currentRow < startingRow + rowsCount; currentRow++)
            {
                this.worksheet.Cells[currentRow, 1] = null;
                this.worksheet.Cells[currentRow, 2] = null;
                this.worksheet.Cells[currentRow, 3] = null;
            }
        }
    }
}