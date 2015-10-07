namespace BoardgameSimulator.ConsoleApp
{
    using Models;
    using Data;

    public class ConsoleApp
    {
        public static void Main()
        {
            var context = new BoardgameSimulatorDbContext();

            context.Units.Add(new Unit()
            {
                AttackRate = 1.75,
                AttackType = AttackType.Melee,
                Damage = 45,
                Health = 20,
                Name = "Vicious Swordsman"
            });

            context.SaveChanges();
        }
    }
}
