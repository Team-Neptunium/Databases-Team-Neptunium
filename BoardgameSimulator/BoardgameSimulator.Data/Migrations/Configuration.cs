namespace BoardgameSimulator.Data.Migrations
{
    using System.Data.Entity.Migrations;

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
        }
    }
}
