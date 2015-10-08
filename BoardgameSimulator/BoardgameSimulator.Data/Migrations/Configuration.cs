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
            /*
            this.SeedUnits(context);
            this.SeedSkills(context);
            this.SeedHeroes(context);
            this.SeedAlignments(context);
            this.SeedArmies(context);
             * */
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
                Inventory =
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
                AttackType = AttackType.LightMelee,
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

        private void SeedAlignments(BoardgameSimulatorDbContext context)
        {
            if (context.AlignmentPerks.Any())
            {
                return;
            }

            context.AlignmentPerks.Add(new AlignmentPerk
            {
                Name = "Lawful Good",
                Type = "Good",
                DamageMultiplier = 1.1,
                HealthMultiplier = 1.15
            });

            context.AlignmentPerks.Add(new AlignmentPerk
            {
                Name = "Chaotic Evil",
                Type = "Evil",
                DamageMultiplier = 1.25,
                HealthMultiplier = 0.85
            });
        }

        private void SeedArmies(BoardgameSimulatorDbContext context)
        {
            if (context.Armies.Any())
            {
                return;
            }

            context.Armies.Add(new Army
            {
                Unit = new Unit
                {
                    AttackRate = 2,
                    AttackType = AttackType.Siege,
                    Damage = 50,
                    Health = 20,
                    Name = "Ballista"
                },
                AlignmentPerk = new AlignmentPerk
                {
                    Name = "Mystical Force",
                    Type = "Selfish",
                    DamageMultiplier = 1.12,
                    HealthMultiplier = 1
                },
                Hero = new Hero
                {
                    Name = "Percephone",
                    UnitId = 2,
                    SkillId = 2,
                    Inventory =
                {
                    new Item
                    {
                        DamageBonus = 70,
                        HealthBonus = 55,
                        Name = "Rainbow Harp"
                    }
                }
                },
                UnitQuantity = 30
            });
        }

    }
}
