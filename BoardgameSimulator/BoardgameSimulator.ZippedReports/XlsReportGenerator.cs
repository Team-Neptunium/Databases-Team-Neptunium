namespace BoardgameSimulator.ZippedReports
{
    using System;
    using System.IO;
    using System.Reflection;
    using System.Runtime.InteropServices;

    using Microsoft.Office.Interop.Excel;

    public class XlsReportGenerator : IDisposable
    {
        private const string AlignmentFolderName = "AlignmentID-";
        private const string ReportFileName = "Report-";

        private const int StartRow = 2;
        private static readonly string[] FirstRowInSheet = { "HeroID", "UnitsID", "Units Quantity" };

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
        public void GenerateXlsAlignmentsReports(
            int alignmentCount, 
            int minReportsCountPerAlignment, 
            int maxReportsCountPerAlignment, 
            int minArmiesPerAlignmentCount, 
            int maxArmiesPerAlignmentCount, 
            string rootDirectory)
        {
            this.FillRow(1, FirstRowInSheet);

            for (int currentAlignment = 1; currentAlignment <= alignmentCount; currentAlignment++)
            {
                string currentFolder = Path.Combine(rootDirectory, AlignmentFolderName + currentAlignment);
                Directory.CreateDirectory(currentFolder);

                int reportsCount = this.rnd.Next(minReportsCountPerAlignment, maxReportsCountPerAlignment + 1);
                this.SaveReports(reportsCount, currentFolder, minArmiesPerAlignmentCount, maxArmiesPerAlignmentCount);
            }
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