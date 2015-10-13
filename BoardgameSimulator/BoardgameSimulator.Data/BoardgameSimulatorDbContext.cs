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

        public virtual IDbSet<AlignmentPerk> AlignmentPerks { get; set; }
               
        public virtual IDbSet<Unit> Units { get; set; }
               
        public virtual IDbSet<Skill> Skills { get; set; }
              
        public virtual IDbSet<Item> Items { get; set; }
              
        public virtual IDbSet<Hero> Heroes { get; set; }
              
        public virtual IDbSet<Army> Armies { get; set; }
              
        public virtual IDbSet<BattleLog> BattleLogs { get; set; }
              
        public virtual new IDbSet<T> Set<T>() where T : class
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
