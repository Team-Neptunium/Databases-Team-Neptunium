using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using BoardgameSimulator.Data;
using BoardgameSimulator.DummyModels.AlignmentPerks;
using BoardgameSimulator.DummyModels.Heroes;
using BoardgameSimulator.DummyModels.Skills;
using BoardgameSimulator.DummyModels.Units;
using BoardgameSimulator.Models;
using BoardgameSimulator.MongoDB;
using BoardgameSimulator.MongoDB.Data;
using BoardgameSimulator.Reports;

namespace BoardgameSimulator.ConsoleApp
{
    public class ConsoleApp
    {
        public static void Main()   
        {
            const string mongoDbName = "boardgamesimulatormongodb";

            var data = new BoardgameSimulatorData(new BoardgameSimulatorDbContext());

            //ConnectToMongoAndSeedToMSSQL(mongoDbName, data);
        }

        private static void ConnectToMongoAndSeedToMSSQL(string mongoDbName, BoardgameSimulatorData data)
        {
            var mongoConnection = new MongoConnection();

            mongoConnection.Connect(mongoDbName);

            var skills = new GenericData<DummySkill>(mongoConnection.Database, "skills");
            var units = new GenericData<DummyUnit>(mongoConnection.Database, "units");
            var perks = new GenericData<DummyAlignmentPerk>(mongoConnection.Database, "perks");
            var heroes = new GenericData<DummyHero>(mongoConnection.Database, "heroes");

            var skillsFromMongo = skills.GetAllDataFromCollection();
            var unitsFromMongo = units.GetAllDataFromCollection();
            var perksFromMongo = perks.GetAllDataFromCollection();
            var heroesFromMongo = heroes.GetAllDataFromCollection();

            //SeedDataFromMongoDb(data, skillsFromMongo, unitsFromMongo, perksFromMongo, heroesFromMongo);
        }

        private static void SeedDataFromMongoDb(BoardgameSimulatorData data,
            IEnumerable<DummySkill> skillsFromMongo,
            IEnumerable<DummyUnit> unitsFromMongo,
            IEnumerable<DummyAlignmentPerk> perksFromMongo,
            IEnumerable<DummyHero> heroesFromMongo)
        {
            if (data == null)
            {
                return;
            }

            if (skillsFromMongo != null)
            {
                SeedSkills(data, skillsFromMongo);
                data.SaveChanges();
                Console.WriteLine("Skill entries successfully seeded into SQL");
            }

            if (unitsFromMongo != null)
            {
                SeedUnits(data, unitsFromMongo);
                data.SaveChanges();
                Console.WriteLine("Unit entries successfully seeded into SQL");
            }

            if (perksFromMongo != null)
            {
                SeedPerks(data, perksFromMongo);
                data.SaveChanges();
                Console.WriteLine("Perk entries successfully seeded into SQL");
            }

            if (heroesFromMongo != null)
            {
                SeedHeroes(data, heroesFromMongo);
                data.SaveChanges();
                Console.WriteLine("Hero entries successfully seeded into SQL");
            }
        }

        private static void SeedSkills(BoardgameSimulatorData data, IEnumerable<DummySkill> skills)
        {
            foreach (var skill in skills)
            {
                data.Skills.Add(new Skill
                {
                    Name = skill.Name,
                    Cooldown = skill.Cooldown,
                    Damage = skill.Damage
                });
            }
        }

        private static void SeedUnits(BoardgameSimulatorData data, IEnumerable<DummyUnit> units)
        {
            foreach (var unit in units)
            {
                data.Units.Add(new Unit
                {
                    Name = unit.Name,
                    AttackType = (AttackType)unit.AttackType,
                    Damage = unit.Damage,
                    AttackRate = unit.AttackRate,
                    Health = unit.Health
                });
            }
        }

        private static void SeedPerks(BoardgameSimulatorData data, IEnumerable<DummyAlignmentPerk> perks)
        {
            foreach (var perk in perks)
            {
                data.AlignmentPerks.Add(new AlignmentPerk
                {
                    Name = perk.Name,
                    Type = perk.Type,
                    DamageMultiplier = perk.DamageModifier,
                    HealthMultiplier = perk.HealthModifier
                });
            }
        }

        private static void SeedHeroes(BoardgameSimulatorData data, IEnumerable<DummyHero> heroes)
        {
            foreach (var hero in heroes)
            {
                data.Heroes.Add(new Hero
                {
                    Name = hero.Name,
                    UnitId = hero.UnitId,
                    SkillId = hero.SkillId,
                });
            }
        }
    }
}
