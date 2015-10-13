namespace BoardgameSimulator.Reports
{
    using System.IO;
    using Models;
    using Newtonsoft.Json;

    /// <summary>
    /// Generator for data in .json
    /// </summary>
    public class JsonGenerator
    {
        private static volatile JsonGenerator _instance;
        private static readonly object _lockThis = new object();

        private JsonGenerator()
        {
        }

        /// <summary>
        /// Introducing Singleton
        /// </summary>
        public static JsonGenerator Instance()
        {
            if (_instance == null)
            {
                lock (_lockThis)
                {
                    if (_instance == null)
                    {
                        _instance = new JsonGenerator();
                        Directory.CreateDirectory(@"C:\Temp\JSONs");
                    }
                }
            }

            return _instance;
        }

        /// <summary>
        /// Creates .json with data from AlignmentPerk
        /// </summary>
        public void CreateJsonAlignmentPerk(AlignmentPerk alignmentPerk)
        {
            string json = JsonConvert.SerializeObject(alignmentPerk, Formatting.Indented);

            File.WriteAllText(@"C:\Temp\JSONs\" + alignmentPerk.Id.ToString() + ".json", json);
        }

        /// <summary>
        /// Creates .json with data from Army
        /// </summary>
        public void CreateJsonArmy(Army army)
        {
            string json = JsonConvert.SerializeObject(army, Formatting.Indented);

            File.WriteAllText(@"C:\Temp\JSONs\" + army.Id.ToString() + ".json", json);
        }

        /// <summary>
        /// Creates .json with data from Hero
        /// </summary>
        public void CreateJsonHero(Hero hero)
        {
            string json = JsonConvert.SerializeObject(hero, Formatting.Indented);

            File.WriteAllText(@"C:\Temp\JSONs\" + hero.Id.ToString() + ".json", json);
        }

        /// <summary>
        /// Creates .json with data from Item
        /// </summary>
        public void CreateJsonItem(Item item)
        {
            string json = JsonConvert.SerializeObject(item, Formatting.Indented);

            File.WriteAllText(@"C:\Temp\JSONs\" + item.Id.ToString() + ".json", json);
        }

        /// <summary>
        /// Creates .json with data from Skill
        /// </summary>
        public void CreateJsonSkill(Skill skill)
        {
            string json = JsonConvert.SerializeObject(skill, Formatting.Indented);

            File.WriteAllText(@"C:\Temp\JSONs\" + skill.Id.ToString() + ".json", json);
        }

        /// <summary>
        /// Creates .json with data from Unit
        /// </summary>
        public void CreateJsonUnit(Unit unit)
        {
            string json = JsonConvert.SerializeObject(unit, Formatting.Indented);

            File.WriteAllText(@"C:\Temp\JSONs\" + unit.Id.ToString() + ".json", json);
        }
    }
}
