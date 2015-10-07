using System.Linq;

namespace BoardgameSimulator.ConsoleApp
{
    using Models;
    using Data;

    public class ConsoleApp
    {
        public static void Main()
        {
            var context = new BoardgameSimulatorDbContext();

            context.Database.Initialize(true);

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
                    Type = AlignmentType.Selfish,
                    DamageMultiplier = 1.12,
                    HealthMultiplier = 1
                },
                Hero = new Hero
                {
                    Name = "Percephone",
                    Unit = new Unit
                    {
                        AttackRate = 1.75,
                        AttackType = AttackType.Melee,
                        Damage = 45,
                        Health = 20,
                        Name = "Vicious Swordsman"
                    },
                    Skill = new Skill
                    {
                        Cooldown = 150,
                        Damage = 300,
                        Name = "Boulder Toss"
                    },
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

            context.SaveChanges();

        }
    }
}
