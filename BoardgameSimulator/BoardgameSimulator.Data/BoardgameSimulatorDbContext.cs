namespace BoardgameSimulator.Data
{
    using System.Data.Entity;

    using Migrations;
    using Models;

    public class BoardgameSimulatorDbContext : DbContext, IBoardgameSimulatorDbContext
    {
        public BoardgameSimulatorDbContext()
            : base("BoardgameSimulatorConnection")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<BoardgameSimulatorDbContext, Configuration>());

            //Database.SetInitializer(new DropCreateDatabaseAlways<BoardgameSimulatorDbContext>());
        }

        public IDbSet<AlignmentPerk> AlignmentPerks { get; set; }

        public IDbSet<Unit> Units { get; set; }

        public IDbSet<Skill> Skills { get; set; }

        public IDbSet<Item> Items { get; set; }

        public IDbSet<Hero> Heroes { get; set; }

        public IDbSet<Army> Armies { get; set; }

        public IDbSet<BattleLog> BattleLogs { get; set; }

        public new IDbSet<T> Set<T>() where T : class
        {
            return base.Set<T>();
        }

        public new void SaveChanges()
        {
            base.SaveChanges();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //one-to-many 

            modelBuilder.Entity<Hero>()
                .HasOptional(h => h.Unit)
                .WithMany()
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Hero>()
                .HasOptional(h => h.Skill)
                .WithMany()
                .WillCascadeOnDelete(false);
            
            modelBuilder.Entity<BattleLog>()
                .HasRequired(bl => bl.Army1)
                .WithMany()
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<BattleLog>()
                .HasRequired(bl => bl.Army2)
                .WithMany()
                .WillCascadeOnDelete(false);
        }

    }
}
