namespace BoardgameSimulator.Reports
{
    using System.Collections.Generic;
    using System.IO;
    using Models;
    using iTextSharp.text;
    using iTextSharp.text.pdf;

    /// <summary>
    /// Generator for tables in .pdf
    /// </summary>
    public class PdfGenerator
    {
        private static volatile PdfGenerator _instance;
        private static readonly object _lockThis = new object();

        private PdfGenerator()
        {
        }

        /// <summary>
        /// Introducing Singleton
        /// </summary>
        public static PdfGenerator Instance()
        {
            if (_instance == null)
            {
                lock (_lockThis)
                {
                    if (_instance == null)
                    {
                        _instance = new PdfGenerator();
                        Directory.CreateDirectory(@"C:\Temp\PDFs");
                    }
                }
            }

            return _instance;
        }

        /// <summary>
        /// Generates .pdf with data from AlignmentPerks
        /// </summary>
        public void CreatePdfAlignmentPerks(List<AlignmentPerk> alignmentPerks)
        {
            using (var fileStream = new FileStream(@"C:\Temp\PDFs\AlignmentPerks.pdf", FileMode.Create, FileAccess.Write))
            {
                var document = new Document(PageSize.A4, 2, 2, 30, 30);
                PdfWriter writer = PdfWriter.GetInstance(document, fileStream);
                document.Open();

                var table = new PdfPTable(5);

                // Header
                var headerCell = new PdfPCell(new Phrase("AlignmentPerks"));
                headerCell.Colspan = 5;
                headerCell.BackgroundColor = new BaseColor(232, 232, 232);
                headerCell.HorizontalAlignment = 1; // Centered
                table.AddCell(headerCell);

                table.AddCell("Id");
                table.AddCell("Name");
                table.AddCell("Type");
                table.AddCell("HealthMultiplier");
                table.AddCell("DamageMultiplier");

                foreach (var alignmentPerk in alignmentPerks)
                {
                    table.AddCell(alignmentPerk.Id.ToString());
                    table.AddCell(alignmentPerk.Name.ToString());
                    table.AddCell(alignmentPerk.Type.ToString());
                    table.AddCell(alignmentPerk.HealthMultiplier.ToString());
                    table.AddCell(alignmentPerk.DamageMultiplier.ToString());
                }

                document.Add(table);
                document.Close();
            }
        }

        /// <summary>
        /// Generates .pdf with data from Armies
        /// </summary>
        public void CreatePdfArmies(List<Army> armies)
        {
            using (var fileStream = new FileStream(@"C:\Temp\PDFs\Armies.pdf", FileMode.Create, FileAccess.Write))
            {
                var document = new Document(PageSize.A4, 2, 2, 30, 30);
                PdfWriter writer = PdfWriter.GetInstance(document, fileStream);
                document.Open();

                var table = new PdfPTable(5);

                // Header
                var headerCell = new PdfPCell(new Phrase("Armies"));
                headerCell.Colspan = 5;
                headerCell.BackgroundColor = new BaseColor(232, 232, 232);
                headerCell.HorizontalAlignment = 1; // Centered
                table.AddCell(headerCell);

                table.AddCell("Id");
                table.AddCell("AlignmentPerkId");
                table.AddCell("HeroId");
                table.AddCell("UnitId");
                table.AddCell("UnitQuantity");

                foreach (var army in armies)
                {
                    table.AddCell(army.Id.ToString());
                    table.AddCell(army.AlignmentPerkId.ToString());
                    table.AddCell(army.HeroId.ToString());
                    table.AddCell(army.UnitId.ToString());
                    table.AddCell(army.UnitQuantity.ToString());
                }

                document.Add(table);
                document.Close();
            }
        }

        /// <summary>
        /// Generates .pdf with data from Heroes
        /// </summary>
        public void CreatePdfHeroes(List<Hero> heroes)
        {
            using (var fileStream = new FileStream(@"C:\Temp\PDFs\Heroes.pdf", FileMode.Create, FileAccess.Write))
            {
                var document = new Document(PageSize.A4, 2, 2, 30, 30);
                PdfWriter writer = PdfWriter.GetInstance(document, fileStream);
                document.Open();

                var table = new PdfPTable(4);

                // Header
                var headerCell = new PdfPCell(new Phrase("Heroes"));
                headerCell.Colspan = 4;
                headerCell.BackgroundColor = new BaseColor(232, 232, 232);
                headerCell.HorizontalAlignment = 1; // Centered
                table.AddCell(headerCell);

                table.AddCell("Id");
                table.AddCell("Name");
                table.AddCell("UnitId");
                table.AddCell("SkillId");

                foreach (var hero in heroes)
                {
                    table.AddCell(hero.Id.ToString());
                    table.AddCell(hero.Name.ToString());
                    table.AddCell(hero.UnitId.ToString());
                    table.AddCell(hero.SkillId.ToString());
                }

                document.Add(table);
                document.Close();
            }
        }

        /// <summary>
        /// Generates .pdf with data from Items
        /// </summary>
        public void CreatePdfItems(List<Item> items)
        {
            using (var fileStream = new FileStream(@"C:\Temp\PDFs\Items.pdf", FileMode.Create, FileAccess.Write))
            {
                var document = new Document(PageSize.A4, 2, 2, 30, 30);
                PdfWriter writer = PdfWriter.GetInstance(document, fileStream);
                document.Open();

                var table = new PdfPTable(4);

                // Header
                var headerCell = new PdfPCell(new Phrase("Items"));
                headerCell.Colspan = 4;
                headerCell.BackgroundColor = new BaseColor(232, 232, 232);
                headerCell.HorizontalAlignment = 1; // Centered
                table.AddCell(headerCell);

                table.AddCell("Id");
                table.AddCell("Name");
                table.AddCell("DamageBonus");
                table.AddCell("HealthBonus");

                foreach (var item in items)
                {
                    table.AddCell(item.Id.ToString());
                    table.AddCell(item.Name.ToString());
                    table.AddCell(item.DamageBonus.ToString());
                    table.AddCell(item.HealthBonus.ToString());
                }

                document.Add(table);
                document.Close();
            }
        }

        /// <summary>
        /// Generates .pdf with data from Skills
        /// </summary>
        public void CreatePdfSkills(List<Skill> skills)
        {
            using (var fileStream = new FileStream(@"C:\Temp\PDFs\Skills.pdf", FileMode.Create, FileAccess.Write))
            {
                var document = new Document(PageSize.A4, 2, 2, 30, 30);
                PdfWriter writer = PdfWriter.GetInstance(document, fileStream);
                document.Open();

                var table = new PdfPTable(4);

                // Header
                var headerCell = new PdfPCell(new Phrase("Skills"));
                headerCell.Colspan = 4;
                headerCell.BackgroundColor = new BaseColor(232, 232, 232);
                headerCell.HorizontalAlignment = 1; // Centered
                table.AddCell(headerCell);

                table.AddCell("Id");
                table.AddCell("Name");
                table.AddCell("Damage");
                table.AddCell("Cooldown");

                foreach (var skill in skills)
                {
                    table.AddCell(skill.Id.ToString());
                    table.AddCell(skill.Name.ToString());
                    table.AddCell(skill.Damage.ToString());
                    table.AddCell(skill.Cooldown.ToString());
                }

                document.Add(table);
                document.Close();
            }
        }

        /// <summary>
        /// Generates .pdf with data from Units
        /// </summary>
        public void CreatePdfUnits(List<Unit> units)
        {
            using (var fileStream = new FileStream(@"C:\Temp\PDFs\Units.pdf", FileMode.Create, FileAccess.Write))
            {
                var document = new Document(PageSize.A4, 2, 2, 30, 30);
                PdfWriter writer = PdfWriter.GetInstance(document, fileStream);
                document.Open();

                var table = new PdfPTable(6);

                // Header
                var headerCell = new PdfPCell(new Phrase("Units"));
                headerCell.Colspan = 6;
                headerCell.BackgroundColor = new BaseColor(232, 232, 232);
                headerCell.HorizontalAlignment = 1; // Centered
                table.AddCell(headerCell);

                table.AddCell("Id");
                table.AddCell("Name");
                table.AddCell("AttackType");
                table.AddCell("Damage");
                table.AddCell("AttackRate");
                table.AddCell("Health");

                foreach (var unit in units)
                {
                    table.AddCell(unit.Id.ToString());
                    table.AddCell(unit.Name.ToString());
                    table.AddCell(unit.AttackType.ToString());
                    table.AddCell(unit.Damage.ToString());
                    table.AddCell(unit.AttackRate.ToString());
                    table.AddCell(unit.Health.ToString());
                }

                document.Add(table);
                document.Close();
            }
        }
    }
}
