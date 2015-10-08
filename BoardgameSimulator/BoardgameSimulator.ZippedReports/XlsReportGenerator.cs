namespace BoardgameSimulator.ZippedReports
{
    using System;
    using System.Collections.Generic;
    using System.Reflection;
    using System.Runtime.InteropServices;

    using Excel = Microsoft.Office.Interop.Excel;

    public class XlsReportGenerator
    {
        private readonly Random rnd = new Random();

        private readonly List<string> alignments = new List<string>() { "Evil", "Good", "Neutral", "Demigod", "Mythical" };
        private readonly List<string> heroes = new List<string>() { "Bron", "Tor", "Batman", "Dr. Doom", "Grodd", "Hellboy", "Gordon", "Bizzaro", "Sabertooth", "Maxx" };
        private readonly List<string> units = new List<string>() { "Elven Archer", "Shieldmaiden", "Pegasus", "Pixie", "Swordsman" };

        public void GenerateXls(string fileName)
        {
            var excelApp = new Excel.Application { Visible = false };
            var excelWorkbooks = excelApp.Workbooks;
            var excelWorkbook = excelWorkbooks.Add(Missing.Value);
            Excel.Worksheet excelWorksheet = excelWorkbook.ActiveSheet;

            // Populate first row
            excelWorksheet.Cells[1, 2] = "Alignment";
            excelWorksheet.Cells[1, 3] = "Hero";
            excelWorksheet.Cells[1, 4] = "Unit";
            excelWorksheet.Cells[1, 5] = "Unit Quantity";

            excelWorksheet.Cells[1, 7] = "Duration (seconds)";

            // Populate first column
            excelWorksheet.Cells[2, 1] = "First Army";
            excelWorksheet.Cells[3, 1] = "Second Army";

            // Populate alignments
            excelWorksheet.Cells[2, 2] = this.alignments[this.rnd.Next(this.alignments.Count)];
            excelWorksheet.Cells[3, 2] = this.alignments[this.rnd.Next(this.alignments.Count)];

            // Populate heroes
            excelWorksheet.Cells[2, 3] = this.heroes[this.rnd.Next(this.heroes.Count)];
            excelWorksheet.Cells[3, 3] = this.heroes[this.rnd.Next(this.heroes.Count)];

            // Populate units
            excelWorksheet.Cells[2, 4] = this.units[this.rnd.Next(this.units.Count)];
            excelWorksheet.Cells[3, 4] = this.units[this.rnd.Next(this.units.Count)];

            // Populate unit quantities
            excelWorksheet.Cells[2, 5] = this.rnd.Next(1, 201) * 5;
            excelWorksheet.Cells[3, 5] = this.rnd.Next(1, 201) * 5;

            // Duration
            excelWorksheet.Cells[2, 7] = this.rnd.Next(10, 1001);

            // Save and Release COM objects
            Marshal.ReleaseComObject(excelWorksheet);
            excelWorkbook.SaveAs(fileName);
            excelWorkbook.Close(true);
            Marshal.ReleaseComObject(excelWorkbook);
            Marshal.ReleaseComObject(excelWorkbooks);
            excelApp.Quit();
            Marshal.ReleaseComObject(excelApp);
        }
    }
}