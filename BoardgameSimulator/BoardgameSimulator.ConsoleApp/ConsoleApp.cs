using BoardgameSimulator.DummyInfo.AlignmentPerks;
using BoardgameSimulator.DummyInfo.Heroes;
using BoardgameSimulator.DummyInfo.Skills;
using BoardgameSimulator.DummyInfo.Units;

namespace BoardgameSimulator.ConsoleApp
{
    using System;
    using System.Linq;

    using Models;
    using Data;
    using DummyInfo;

    public class ConsoleApp
    {
        public static void Main()
        {
            var data = new BoardgameSimulatorData(new BoardgameSimulatorDbContext());

            /*
            var dummyUnits = Units.GenerateUnitsList(100, 12345, 10, 10);
            var i = 0;
            foreach (var entry in dummyUnits)
            {

                Console.WriteLine(i + " {0} - Attack: {1}, Dmg: {2}, Rate: {3}, Hp: {4}", entry.Name, entry.AttackType, entry.Damage, entry.AttackRate, entry.Health);
                i++;
            }

            Console.WriteLine("\n\n");

            var skills = Skills.GenerateSkillsList();
            foreach (var skill in skills)
            {
                Console.WriteLine("{0} - Damage: {1}, CD: {2}", skill.Name, skill.Damage, skill.Cooldown);
            }

            Console.WriteLine("\n\n");

            var heroes = Heroes.GenerateHeroesList();
            foreach (var hero in heroes)
            {
                Console.WriteLine("{0} - UnitId: {1}, SkillId: {2}", hero.Name, hero.UnitId, hero.SkillId);
            }

            Console.WriteLine("\n\n");

            var perks = AlignmentPerks.GenerateAlignmentsList();
            foreach (var perk in perks)
            {
                Console.WriteLine("{0} - Type: {1}, DmgMod: {2}, HpMod: {3}", perk.Name, perk.Type, perk.DamageModifier, perk.HealthModifier);
            }
            */
             
            #region sample data

            ////
            //// Do not add logs as in the lines below yet, battlelogs not fully implemented
            //// 
            /*
            data.BattleLogs.Add(new BattleLog
            {
                Army1Id = 5,
                Army2Id = 10,
                Date = DateTime.Today
            });

            data.SaveChanges();

            var log = data.BattleLogs.All().ToList();

            foreach (var battleLog in log)
            {
                Console.WriteLine(battleLog.Army1.Hero.Name + " leading army N1 spars against army N2 lead by " + battleLog.Army2.Hero.Name);
            }
            */

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
                Type = "Neutral",
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
