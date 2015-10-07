using BoardgameSimulator.Models;

namespace BoardgameSimulator.Data.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<BoardgameSimulatorDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
            ContextKey = "BoardgameSimulator.Data.BoardgameSimulatorDbContext";
        }

        protected override void Seed(BoardgameSimulatorDbContext context)
        {
            this.SeedUnits(context);
            this.SeedSkills(context);
            this.SeedHeroes(context);
        }

        public void SeedHeroes(BoardgameSimulatorDbContext context)
        {
            if (context.Heroes.Any())
            {
                return;
            }

            context.Heroes.Add(new Hero
            {
                Name = "Bucephalus",
                UnitId = 1,
                SkillId = 1,
                Items =
                {
                    new Item
                    {
                        DamageBonus = 200,
                        HealthBonus = 200,
                        Name = "Gosho's Bloodied Axe"
                    }
                }
            });
        }

        public void SeedUnits(BoardgameSimulatorDbContext context)
        {
            if (context.Units.Any())
            {
                return;
            }

            context.Units.Add(new Unit
            {
                AttackRate = 1.75,
                AttackType = AttackType.Melee,
                Damage = 45,
                Health = 20,
                Name = "Vicious Swordsman"
            });

            context.Units.Add(new Unit
            {
                AttackRate = 2,
                AttackType = AttackType.Ranged,
                Damage = 20,
                Health = 25,
                Name = "Stone-hurler"
            });
        }

        public void SeedSkills(BoardgameSimulatorDbContext context)
        {
            if (context.Skills.Any())
            {
                return;
            }

            context.Skills.Add(new Skill
            {
                Cooldown = 70,
                Damage = 260,
                Name = "Adamant Slash"
            });

            context.Skills.Add(new Skill
            {
                Cooldown = 150,
                Damage = 300,
                Name = "Boulder Toss"
            });
        }
    }
}
