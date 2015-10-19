namespace BoardgameSimulator.Importer
{
    using System;
    using System.Collections.Generic;
    using System.Xml;

    using DummyModels.Items;
    using Data;
    using Models;
    using DummyModels.Heroes;

    #region Xml example
    //<?xml version="1.0" encoding="utf-8" ?>
    //<heroes>
    //  <hero id="1">
    //    <name>Dangerous Tybalt Filthpit</name>  
    //    <unitId>127</unitId>
    //    <skillId>11</skillId>
    //    <items>
    //      <item name="Pile of Soiled Essence">
    //        <dmgBonus>40</dmgBonus>
    //        <hpBonus>92</hpBonus>
    //      </item>
    //      <item name="Onyx Sliver">
    //        <dmgBonus>42</dmgBonus>
    //        <hpBonus>91</hpBonus>
    //      </item>
    //    </items>
    //  </hero>
    //
    //  <hero id="2">
    //    <name>Deadly Wynne The Vile</name>  
    //    <unitId>21</unitId>
    //    <skillId>95</skillId>
    //    <items>
    //      <item name="Large Fang">
    //        <dmgBonus>100</dmgBonus>
    //        <hpBonus>1020</hpBonus>
    //      </item>
    //    </items>
    //  </hero>
    //
    //  <hero id="3">
    //    <name>Resistant Nizoon The Fiend</name>  
    //    <unitId>36</unitId>
    //    <skillId>63</skillId>
    //    <items>
    //      <item name="Smooth Scale">
    //        <dmgBonus>75</dmgBonus>
    //        <hpBonus>422</hpBonus>
    //      </item>
    //      <item name="Armored Scale">
    //        <dmgBonus>175</dmgBonus>
    //        <hpBonus>412</hpBonus>
    //      </item>
    //      <item name="Tiny Totem">
    //        <dmgBonus>1175</dmgBonus>
    //        <hpBonus>642</hpBonus>
    //      </item>
    //    </items>
    //  </hero>
    //
    //  <hero id="4">
    //    <name>Wealthy Sierra The Noble</name>  
    //    <unitId>78</unitId>
    //    <skillId>88</skillId>
    //    <items>
    //      <item name="Tiny Venom Sac">
    //        <dmgBonus>199</dmgBonus>
    //        <hpBonus>51</hpBonus>
    //      </item>
    //      <item name="Powerful Venom Sac">
    //        <dmgBonus>909</dmgBonus>
    //        <hpBonus>515</hpBonus>
    //      </item>
    //      <item name="Sun Bead">
    //        <dmgBonus>99</dmgBonus>
    //        <hpBonus>5111<hpBonus>
    //      </item>
    //      <item name="Giant Eye">
    //        <dmgBonus>9119</dmgBonus>
    //        <hpBonus>51123</hpBonus>
    //      </item>
    //    </items>
    //  </hero>
    //</heroes>
    #endregion

    public class XmlImporter
    {
        private BoardgameSimulatorData data;

        public XmlImporter(string filePath, BoardgameSimulatorData data)
        {
            this.FilePath = filePath;
            this.data = data;
        }

        public string FilePath { get; private set; }

        public void ImportToSql()
        {
            this.AddHeroesToSql();
            this.AddItemsToSql();
            Console.WriteLine("Heroes and items added sucessfully from .xml to Sql!");
        }

        private void AddHeroesToSql()
        {
            foreach (var hero in this.GetHeroes())
            {
                this.data.Heroes.Add(new Hero()
                {
                    Name = hero.Name,
                    UnitId = hero.UnitId,
                    SkillId = hero.SkillId
                });
            }

            this.data.SaveChanges();
        }

        private void AddItemsToSql()
        {
            foreach (var item in this.GetItems())
            {
                this.data.Items.Add(new Item()
                {
                    Name = item.Name,
                    DamageBonus = item.DamageBonus,
                    HealthBonus = item.HealthBonus,
                    HeroId = item.HeroId
                });
            }

            this.data.SaveChanges();
        }

        private List<DummyItem> GetItems()
        {
            var listOfItems = new List<DummyItem>();

            XmlDocument doc = new XmlDocument();
            doc.Load(this.FilePath);

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

        private List<DummyHero> GetHeroes()
        {
            var listOfHeroes = new List<DummyHero>();

            XmlDocument doc = new XmlDocument();
            doc.Load(this.FilePath);

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
