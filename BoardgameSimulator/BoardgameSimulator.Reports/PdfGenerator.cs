namespace BoardgameSimulator.Reports
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Numerics;
    using Models;
    using iTextSharp.text;
    using iTextSharp.text.pdf;

    public class PdfGenerator
    {
        private string workingDir = ".../.../.../Reports/Pdf";

        public PdfGenerator()
        {
            if (!Directory.Exists(workingDir))
            {
                Directory.CreateDirectory(workingDir);
            }
        }

        public void CreatePerksGroupArmyReport(IQueryable<Army> armydata)
        {
            using (var fs = new FileStream(Path.Combine(workingDir, "ArmiesAndPerksReport.pdf"), FileMode.Create, FileAccess.Write))
            {
                Console.WriteLine("Generating of ArmiesAndPerksReport.pdf initialized.");

                var document = new Document(PageSize.A4, 2, 2, 30, 30);
                PdfWriter.GetInstance(document, fs);
                document.Open();

                var groups = armydata.Select(a => new
                {
                    AlignmentPerk = a.AlignmentPerk.Name,
                    Hero = a.Hero.Name,
                    UnitName = a.Unit.Name,
                    UnitDamage = a.Unit.Damage,
                    UnitAttackRate = a.Unit.AttackRate,
                    Quantity = a.UnitQuantity
                })
                .GroupBy(x => x.AlignmentPerk)
                .ToList();

                var armiesgroupedByPerk = groups;

                BigInteger totalDamage = 0;

                for (int i = 0; i < armiesgroupedByPerk.Count; i++)
                {
                    var perk = armiesgroupedByPerk[i];

                    var table = new PdfPTable(6);

                    var headerCell = new PdfPCell(new Phrase("Army perk: " + perk.Key));
                    headerCell.Colspan = 6;
                    headerCell.BackgroundColor = new BaseColor(232, 232, 232);
                    headerCell.HorizontalAlignment = 1;
                    table.AddCell(headerCell);

                    table.AddCell("Hero");
                    table.AddCell("Units");
                    table.AddCell("Damage");
                    table.AddCell("Rate");
                    table.AddCell("Quantity");
                    table.AddCell("Total Damage / Sec");

                    foreach (var army in perk)
                    {
                        table.AddCell(army.Hero);
                        table.AddCell(army.UnitName);
                        table.AddCell(army.UnitDamage.ToString());
                        table.AddCell(army.UnitAttackRate.ToString());
                        table.AddCell(army.Quantity.ToString());

                        var dps = CalculateDmgPotential(army.Quantity, army.UnitDamage, army.UnitAttackRate);
                        totalDamage += dps;

                        table.AddCell(((double)dps/1000) + "k");
                    }

                    document.Add(table);
                    document.Add(new Paragraph(new Phrase("\n")));
                }

                var footer = new Paragraph(new Phrase("Total damage: " + totalDamage + " / sec"));
                footer.Alignment = 1;

                document.Add(footer);
                document.Close();

                Console.WriteLine("Generating of pdf report completed!");
            }
        }

        public void CreatePdfSkillsPotentialReport(IEnumerable<Skill> skills)
        {
            using (var fs = new FileStream(Path.Combine(workingDir, "SkillsPotentialReport.pdf"), FileMode.Create, FileAccess.Write))
            {
                Console.WriteLine("Generating of SkillsPotentialReport.pdf initialized.");

                var document = new Document(PageSize.A4, 2, 2, 30, 30);
                PdfWriter.GetInstance(document, fs);
                document.Open();

                skills = skills.ToList();

                double totalDamage = 0;

                var table = new PdfPTable(4);

                var headerCell = new PdfPCell(new Phrase("Skills"));
                headerCell.Colspan = 4;
                headerCell.BackgroundColor = new BaseColor(232, 232, 232);
                headerCell.HorizontalAlignment = 1;
                table.AddCell(headerCell);

                table.AddCell("Skill");
                table.AddCell("Damage");
                table.AddCell("Cooldown");
                table.AddCell("Total Damage / Sec");

                foreach (var skill in skills)
                {
                    table.AddCell(skill.Name);
                    table.AddCell(skill.Damage.ToString());
                    table.AddCell(skill.Cooldown.ToString());

                    var damagePotential = CalculateSkillPotential(skill.Damage, skill.Cooldown);
                    totalDamage += damagePotential;

                    table.AddCell(string.Format("{0:F3}", damagePotential));
                }

                document.Add(table);

                var footer = new Paragraph(new Phrase("Total damage: " + totalDamage + " / sec"));
                footer.Alignment = 1;

                document.Add(footer);
                document.Close();

                Console.WriteLine("Generating of pdf report completed!");
            }
        }
        
        private int CalculateDmgPotential(int quantity, int damage, double rate)
        {
            return (int)(quantity * (damage / rate));
        }

        private double CalculateSkillPotential(int damage, int cd)
        {
            return (double)damage / cd;
        }

    }
}
