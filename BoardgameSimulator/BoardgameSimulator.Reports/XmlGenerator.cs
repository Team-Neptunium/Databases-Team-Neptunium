namespace BoardgameSimulator.Reports
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml;

    using Models;
    using Telerik.OpenAccess;

    public class XmlGenerator
    {
        private string workingDir = ".../.../.../Reports/Xml";

        public XmlGenerator()
        {
            if (!Directory.Exists(workingDir))
            {
                Directory.CreateDirectory(workingDir);
            }
        }

        public void CreateHeroesReport(IQueryable<Hero> heroesData)
        {
            Encoding encoding = Encoding.GetEncoding("windows-1251");

            using (XmlTextWriter writer = new XmlTextWriter(workingDir + "/Heroes.xml", encoding))
            {
                Console.WriteLine("Writing of Heroes.xml initialized.");

                writer.Formatting = Formatting.Indented;
                writer.IndentChar = ' ';
                writer.Indentation = 2;

                writer.WriteStartDocument();
                writer.WriteStartElement("heroes");

                var heroes = heroesData.ToList();
                foreach (var hero in heroes)
                {
                    this.WriteHero(writer, hero);
                }

                writer.WriteEndDocument();
                Console.WriteLine("Heroes.xml created!");
            }
        }

        private void WriteHero(XmlWriter writer, Hero hero)
        {
            writer.WriteStartElement("hero");

            writer.WriteAttributeString("id", hero.Id.ToString());
            writer.WriteElementString("name", hero.Name);
            writer.WriteElementString("unitType", hero.Unit.Name);
            writer.WriteElementString("skill", hero.Skill.Name);
            writer.WriteStartElement("items");

            foreach (var item in hero.Items)
            {
                this.WriteItem(writer, item);
            }

            writer.WriteEndElement();
            writer.WriteEndElement();
        }

        private void WriteItem(XmlWriter writer, Item item)
        {
            writer.WriteStartElement("item");
            writer.WriteAttributeString("name", item.Name);
            writer.WriteElementString("dmgBonus", item.DamageBonus.ToString());
            writer.WriteElementString("hpBonus", item.HealthBonus.ToString());
            writer.WriteEndElement();
        }
    }
}
