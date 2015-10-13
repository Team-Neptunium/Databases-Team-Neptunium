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
            
        }

    }
}
