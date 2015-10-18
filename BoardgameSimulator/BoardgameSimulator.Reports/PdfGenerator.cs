namespace BoardgameSimulator.Reports
{
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

        public void CreatePerksGroupArmyReport(IEnumerable<Army> armies)
        {
            using (var fs = new FileStream(Path.Combine(workingDir, "ArmiesAndPerksReport.pdf"), FileMode.Create, FileAccess.Write))
            {
                var document = new Document(PageSize.A4, 2, 2, 30, 30);
                PdfWriter.GetInstance(document, fs);
                document.Open();

                var armydata = armies.ToList();

                var armiesgroupedByPerk = armydata.GroupBy(x => x.AlignmentPerk.Name).ToList();

                BigInteger totalDamage = 0;

                for (int i = 0; i < armiesgroupedByPerk.Count; i++)
                {
                    var perk = armiesgroupedByPerk[i];

                    var table = new PdfPTable(6);

                    // Header
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
                        table.AddCell(army.Hero.Name);
                        table.AddCell(army.Unit.Name);
                        table.AddCell(army.Unit.Damage.ToString());
                        table.AddCell(army.Unit.AttackRate.ToString());
                        table.AddCell(army.UnitQuantity.ToString());

                        var dps = CalculateDmgPotential(army.UnitQuantity, army.Unit.Damage, army.Unit.AttackRate);
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
            }
        }

        public void CreatePdfSkillsPotentialReport(IEnumerable<Skill> skills)
        {
            using (var fs = new FileStream(Path.Combine(workingDir, "SkillsPotentialReport.pdf"), FileMode.Create, FileAccess.Write))
            {
                var document = new Document(PageSize.A4, 2, 2, 30, 30);
                PdfWriter.GetInstance(document, fs);
                document.Open();

                skills = skills.ToList();

                double totalDamage = 0;

                var table = new PdfPTable(4);

                // Header
                var headerCell = new PdfPCell(new Phrase("Skills"));
                headerCell.Colspan = 4;
                headerCell.BackgroundColor = new BaseColor(232, 232, 232);
                headerCell.HorizontalAlignment = 1; // Centered
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
