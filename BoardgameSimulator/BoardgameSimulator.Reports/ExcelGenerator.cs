namespace BoardgameSimulator.Reports
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using Bytescout.Spreadsheet;
    using Models;
    using MySqlDB.Models;

    public class ExcelGenerator
    {
        private string workingDir = ".../.../.../Reports/Excel2007";
        private string fileName = "ExpensesLog";

        public ExcelGenerator()
        {
            if (!Directory.Exists(workingDir))
            {
                Directory.CreateDirectory(workingDir);
            }
        }

        public void CreateBattleLogExcelReport(IEnumerable<ArmyVsArmyReport> armyVsArmy, IEnumerable<UnitCost> unitCost)
        {
            var data = GenerateData(armyVsArmy, unitCost);

            Spreadsheet document = new Spreadsheet();
            Worksheet sheet = document.Workbook.Worksheets.Add("Battle logs");

            sheet.Cell(1, 0).Value = "Army";

            sheet.Cell(0, 1).Value = "Id";
            sheet.Columns[1].Width = 30;

            sheet.Cell(0, 2).Value = "Unit";
            sheet.Columns[2].Width = 250;

            sheet.Cell(0, 3).Value = "Quantity";
            sheet.Columns[3].Width = 100;

            sheet.Cell(0, 4).Value = "Unit Cost";
            sheet.Columns[4].Width = 100;

            sheet.Cell(0, 5).Value = "Army Expenses";
            sheet.Columns[5].Width = 100;

            sheet.Cell(0, 6).Value = "Date of Battle";
            sheet.Columns[6].Width = 100;

            var currentRow = 1;

            foreach (var entry in data)
            {
                var currentCol = 1;

                sheet.Cell(currentRow, currentCol).Value = entry.Army1Id;
                currentRow++;
                sheet.Cell(currentRow, currentCol).Value = entry.Army2Id;

                currentCol++;
                currentRow--;
                sheet.Cell(currentRow, currentCol).Value = entry.UnitName1;
                currentCol++;
                sheet.Cell(currentRow, currentCol).Value = entry.UnitQuantity1;
                currentCol++;
                sheet.Cell(currentRow, currentCol).Value = entry.UnitCost1;
                currentCol++;
                sheet.Cell(currentRow, currentCol).Value = (entry.UnitCost1*entry.UnitQuantity1)/1000 + "k";
                currentCol++;
                sheet.Cell(currentRow, currentCol).Value = entry.Date.ToShortDateString();

                currentRow++;
                currentCol = 2;
                sheet.Cell(currentRow, currentCol).Value = entry.UnitName2;
                currentCol++;
                sheet.Cell(currentRow, currentCol).Value = entry.UnitQuantity2;
                currentCol++;
                sheet.Cell(currentRow, currentCol).Value = entry.UnitCost2;
                currentCol++;
                sheet.Cell(currentRow, currentCol).Value = (entry.UnitCost2 * entry.UnitQuantity2) /1000 + "k";
                currentCol++;
                sheet.Cell(currentRow, currentCol).Value = entry.Date.ToShortDateString();

                currentRow += 3;
            }
            
            var filePath = Path.Combine(workingDir, fileName + ".xlsx");

            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }

            document.SaveAs(filePath);

            document.Close();
        }

        private IEnumerable<ArmyCostReport> GenerateData(IEnumerable<ArmyVsArmyReport> armyVsArmy, IEnumerable<UnitCost> unitCost)
        {
            var unitCostList = unitCost.ToList();
            var armyVsArmyList = armyVsArmy.ToList();

            var list = new List<ArmyCostReport>();

            for (int i = 0; i < armyVsArmyList.Count; i++)
            {
                var unit = new ArmyCostReport
                {
                    Army1Id = armyVsArmyList[i].Army1Id,
                    Army2Id = armyVsArmyList[i].Army2Id,
                    Date = armyVsArmyList[i].Date,
                    UnitName1 = armyVsArmyList[i].UnitName1,
                    UnitName2 = armyVsArmyList[i].UnitName2,
                    UnitQuantity1 = armyVsArmyList[i].UnitQuantity1,
                    UnitQuantity2 = armyVsArmyList[i].UnitQuantity2
                };

                for (int j = 0; j < unitCostList.Count; j++)
                {
                    if (unit.UnitCost1 != 0 && unit.UnitCost2 != 0)
                    {
                        break;
                    }

                    if (unitCostList[j].UnitName == armyVsArmyList[i].UnitName1)
                    {
                        unit.UnitCost1 = unitCostList[j].RecruitCost;
                    }

                    if (unitCostList[j].UnitName == armyVsArmyList[i].UnitName2)
                    {
                        unit.UnitCost2 = unitCostList[j].RecruitCost;
                    }
                }

                list.Add(unit);
            }

            return list;
        }
    }
}
