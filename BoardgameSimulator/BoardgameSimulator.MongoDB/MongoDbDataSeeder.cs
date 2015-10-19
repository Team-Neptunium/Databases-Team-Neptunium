using MongoDB.Driver;

namespace BoardgameSimulator.MongoDB
{
    using System;
    using System.Collections.Generic;
    using BoardgameSimulator.Data;
    using Data;
    using DummyModels.AlignmentPerks;
    using DummyModels.BattleLogs;
    using DummyModels.Heroes;
    using DummyModels.Skills;
    using DummyModels.Units;
    using Models;

    public class MongoDbDataSeeder
    {
        private const string DropCollectionMessage = "{0} collection dropped.";
        private const string SeedMessage = "{0} {1} entries seeded successfully into the MongoDb!";

        public static void SeedToMongoDb(MongoConnection mongoConnection)
        {
            if (mongoConnection.Database == null)
            {
                mongoConnection.Connect();
            }

            var database = mongoConnection.Database;

            Console.WriteLine("Seeding data to MongoDb initialized.");

            database.DropCollection("skills");
            Console.WriteLine(DropCollectionMessage, "skills");
            database.DropCollection("units");
            Console.WriteLine(DropCollectionMessage, "units");
            database.DropCollection("perks");
            Console.WriteLine(DropCollectionMessage, "perks");
            database.DropCollection("heroes");
            Console.WriteLine(DropCollectionMessage, "heroes");
            database.DropCollection("battlelogs");
            Console.WriteLine(DropCollectionMessage, "battlelogs");

            MongoCollection<DummySkill> skills = database.GetCollection<DummySkill>("skills");
            MongoCollection<DummyUnit> units = database.GetCollection<DummyUnit>("units");
            MongoCollection<DummyAlignmentPerk> perks = database.GetCollection<DummyAlignmentPerk>("perks");
            MongoCollection<DummyHero> heroes = database.GetCollection<DummyHero>("heroes");
            MongoCollection<DummyBattleLog> battleLogs = database.GetCollection<DummyBattleLog>("battlelogs");

            var skillsSeed = DummySkills.GenerateSkillsList();
            var unitsSeed = DummyUnits.GenerateUnitsList(200, 1234, 5, 20);
            var perksSeed = DummyAlignmentPerks.GenerateAlignmentsList(200);
            var heroesSeed = DummyHeroes.GenerateHeroesList(200);
            var battleLogsSeed = DummyBattleLogs.GenerateBattleLogsList();

            var d = skillsSeed.Count;

            skills.InsertBatch(skillsSeed);
            Console.WriteLine(SeedMessage, d, "Skill");
            d = unitsSeed.Count;
            units.InsertBatch(unitsSeed);
            Console.WriteLine(SeedMessage, d, "Unit");
            d = perksSeed.Count;
            perks.InsertBatch(perksSeed);
            Console.WriteLine(SeedMessage, d, "Perk");
            d = heroesSeed.Count;
            heroes.InsertBatch(heroesSeed);
            Console.WriteLine(SeedMessage, d, "Hero");
            d = battleLogsSeed.Count;
            battleLogs.InsertBatch(battleLogsSeed);
            Console.WriteLine(SeedMessage, d, "BattleLog");

            Console.WriteLine("Seeding of MongoDb completed!");
        }

        public static void SeedToSql(MongoConnection mongoConnection, BoardgameSimulatorData data)
        {
            if (mongoConnection.Database == null)
            {
                mongoConnection.Connect();
            }

            if (data == null)
            {
                return;
            }

            var skills = new GenericData<DummySkill>(mongoConnection.Database, "skills");
            var units = new GenericData<DummyUnit>(mongoConnection.Database, "units");
            var perks = new GenericData<DummyAlignmentPerk>(mongoConnection.Database, "perks");
            var heroes = new GenericData<DummyHero>(mongoConnection.Database, "heroes");

            var skillsFromMongo = skills.GetAllDataFromCollection();
            var unitsFromMongo = units.GetAllDataFromCollection();
            var perksFromMongo = perks.GetAllDataFromCollection();
            var heroesFromMongo = heroes.GetAllDataFromCollection();

            SeedDataFromMongoDb(data, skillsFromMongo, unitsFromMongo, perksFromMongo, heroesFromMongo, null);
        }

        public static void SeedBattleLogsToSql(MongoConnection mongoConnection, BoardgameSimulatorData data)
        {
            if (mongoConnection.Database == null)
            {
                mongoConnection.Connect();
            }

            if (data == null)
            {
                return;
            }

            var logs = new GenericData<DummyBattleLog>(mongoConnection.Database, "battlelogs");

            var logsFromMongo = logs.GetAllDataFromCollection();

            SeedDataFromMongoDb(data, null, null, null, null, logsFromMongo);
        }

        private static void SeedDataFromMongoDb(BoardgameSimulatorData data,
            IEnumerable<DummySkill> skillsFromMongo,
            IEnumerable<DummyUnit> unitsFromMongo,
            IEnumerable<DummyAlignmentPerk> perksFromMongo,
            IEnumerable<DummyHero> heroesFromMongo,
            IEnumerable<DummyBattleLog> battleLogsFromMongo)
        {
            Console.WriteLine("Seeeding data from MongoDb into SQL initialized.");

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

            if (battleLogsFromMongo != null)
            {
                SeedBattleLogs(data, battleLogsFromMongo);
                data.SaveChanges();
                Console.WriteLine("BattleLog entries successfully seeded into SQL");
            }

            Console.WriteLine("Seeeding data from MongoDb into SQL completed.");
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

        private static void SeedBattleLogs(BoardgameSimulatorData data,
            IEnumerable<DummyBattleLog> logs)
        {
            foreach (var log in logs)
            {
                data.BattleLogs.Add(new BattleLog
                {
                    Army1Id = log.Army1Id,
                    Army2Id = log.Army2Id,
                    Date = log.Date
                });
            }
        }
    }
}
