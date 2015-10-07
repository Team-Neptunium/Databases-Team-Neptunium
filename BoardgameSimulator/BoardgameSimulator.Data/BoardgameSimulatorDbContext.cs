using BoardgameSimulator.Data.Migrations;

namespace BoardgameSimulator.Data
{
    using System.Data.Entity;

    using Models;

    public class BoardgameSimulatorDbContext : DbContext, IBoardgameSimulatorDbContext
    {
        public BoardgameSimulatorDbContext()
            : base()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<BoardgameSimulatorDbContext, Configuration>());
        }

        public IDbSet<AlignmentPerk> AlignmentPerks { get; set; }

        public IDbSet<Unit> Units { get; set; }

        public IDbSet<Skill> Skills { get; set; }

        public IDbSet<Item> Items { get; set; }

        public IDbSet<Hero> Heroes { get; set; }

        public IDbSet<Army> Armies { get; set; }

        public new IDbSet<T> Set<T>() where T : class
        {
            return base.Set<T>();
        }

        public new void SaveChanges()
        {
            base.SaveChanges();
        }
    }
}
