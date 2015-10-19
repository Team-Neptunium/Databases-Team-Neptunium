namespace BoardgameSimulator.XmlImporter
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Xml;

    using Data;
    using DummyModels.Items;
    using DummyModels.Heroes;
    using Models;
    using MongoDB;

    public class XmlImporter
    {
        public static void ImportToSqlAndMongo(BoardgameSimulatorData data, MongoConnection mongoData, string filePath = "../../../DataSources/xml/")
        {
            if (!Directory.Exists(filePath))
            {
                Console.WriteLine("There are no xml files present in " + filePath + " suitable for importing!");
                return;
            }

            var files = Directory.GetFiles(filePath).Select(x => x).Where(x => Path.GetExtension(x) == ".xml");

            Console.WriteLine("Importing from xml into Sql and MongoDb initialized.");

            foreach (var file in files)
            {
                var heroes = GetHeroes(file);
                var items = GetItems(file);

                Console.WriteLine("importing into sql...");
                AddHeroesToSql(heroes, data);
                AddItemsToSql(items, data);

                Console.WriteLine("importing into mongodb...");
                AddHeroesToMongo(heroes, mongoData);
                AddItemsToMongo(items, mongoData);
            }

            Console.WriteLine("Importing from xml into Sql and MongoDb completed!");
        }

        private static void AddItemsToMongo(List<DummyItem> items, MongoConnection mongoData)
        {
            mongoData.Database.DropCollection("items");

            var itemsCollection = mongoData.Database.GetCollection<DummyItem>("items");

            itemsCollection.InsertBatch(items);
        }

        private static void AddHeroesToMongo(IEnumerable<DummyHero> heroes, MongoConnection mongoData)
        {
            var heroesCollection = mongoData.Database.GetCollection<DummyHero>("heroes");

            heroesCollection.InsertBatch(heroes);
        }

        private static void AddHeroesToSql(IEnumerable<DummyHero> heroes, BoardgameSimulatorData data)
        {
            foreach (var hero in heroes)
            {
                data.Heroes.Add(new Hero()
                {
                    Name = hero.Name,
                    UnitId = hero.UnitId,
                    SkillId = hero.SkillId
                });
            }

            data.SaveChanges();
        }

        private static void AddItemsToSql(IEnumerable<DummyItem> items, BoardgameSimulatorData data)
        {
            foreach (var item in items)
            {
                data.Items.Add(new Item()
                {
                    Name = item.Name,
                    DamageBonus = item.DamageBonus,
                    HealthBonus = item.HealthBonus,
                    HeroId = item.HeroId
                });
            }

            data.SaveChanges();
        }

        private static List<DummyItem> GetItems(string file)
        {
            var listOfItems = new List<DummyItem>();

            XmlDocument doc = new XmlDocument();
            doc.Load(file);

            var rootNode = doc.DocumentElement;
            var heroesList = rootNode.ChildNodes;
            foreach (XmlNode hero in heroesList)
            {
                int heroId = int.Parse(hero.Attributes.Item(0).Value);
                var heroItemsList = hero["items"].ChildNodes;

                foreach (XmlNode item in heroItemsList)
                {
                    string itemName = item.Attributes.Item(0).Value;
                    int itemDmgBonus = int.Parse(item["dmgBonus"].InnerText);
                    int itemHpBonus = int.Parse(item["hpBonus"].InnerText);

                    listOfItems.Add(new DummyItem(itemName, itemDmgBonus, itemHpBonus, heroId));
                }
            }

            return listOfItems;
        }

        private static List<DummyHero> GetHeroes(string file)
        {
            var listOfHeroes = new List<DummyHero>();

            XmlDocument doc = new XmlDocument();
            doc.Load(file);

            var rootNode = doc.DocumentElement;
            var heroes = rootNode.ChildNodes;
            foreach (XmlNode hero in heroes)
            {
                string heroName = hero["name"].InnerText;
                int heroUnitId = int.Parse(hero["unitId"].InnerText);
                int heroSkillId = int.Parse(hero["skillId"].InnerText);

                listOfHeroes.Add(new DummyHero(heroName, heroUnitId, heroSkillId));
            }

            return listOfHeroes;
        }
    }
}
