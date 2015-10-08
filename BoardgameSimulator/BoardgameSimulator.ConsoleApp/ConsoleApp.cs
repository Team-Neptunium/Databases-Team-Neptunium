namespace BoardgameSimulator.ConsoleApp
{
    using System;
    using System.Linq;

    using Models;
    using Data;

    public class ConsoleApp
    {
        public static void Main()
        {
            var data = new BoardgameSimulatorData(new BoardgameSimulatorDbContext());

            #region sample data
            ////
            //// The lines below demonstrate how to add data to an army, thus adding all that supplies the armies like units and heroes
            ////
            /*
            var sampleUnit = new Unit
            {
                AttackRate = 3,
                AttackType = AttackType.Naval,
                Damage = 20,
                Health = 45,
                Name = "Le Ship"
            };

            var sampleUnit2 = new Unit
            {
                AttackRate = 1.25,
                AttackType = AttackType.Ranged,
                Damage = 15,
                Health = 20,
                Name = "'Nother shootah"
            };

            var alignment = new AlignmentPerk
            {
                Name = "Defiant force",
                Type = AlignmentType.Neutral,
                DamageMultiplier = 0.95,
                HealthMultiplier = 1.4
            };

            var item = new Item
            {
                DamageBonus = 45,
                HealthBonus = 10,
                Name = "Shortbow"
            };

            var item2 = new Item
            {
                DamageBonus = 60,
                HealthBonus = 0,
                Name = "Axe"
            };

            var skill = new Skill
            {
                Cooldown = 700,
                Damage = 220,
                Name = "Barrage"
            };

            var hero = new Hero
                {
                    Name = "Leandre",
                    Unit = sampleUnit2,
                    Skill = skill,
                };

            hero.Inventory.Add(item);
            hero.Inventory.Add(item2);

            var army = new Army();

            army.Unit = sampleUnit;
            army.Hero = hero;
            army.AlignmentPerk = alignment;
            army.UnitQuantity = 35;

            data.Armies.Add(army);

            data.SaveChanges();
            
            ////
            //// Adding by Id to already existing entries
            ////
            data.Armies.Add(new Army
            {
                AlignmentPerkId = 1,
                HeroId = 1,
                UnitId = 1,
                UnitQuantity = 2
            });
            data.SaveChanges();
            */
            #endregion
        }
    }
}
