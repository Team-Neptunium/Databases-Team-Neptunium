namespace BoardgameSimulator.Data
{
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;

    using Models;

    public interface IBoardgameSimulatorDbContext
    {
        IDbSet<AlignmentPerk> AlignmentPerks { get; set; }

        IDbSet<Unit> Units { get; set; }

        IDbSet<Skill> Skills { get; set; }

        IDbSet<Item> Items { get; set; }

        IDbSet<Hero> Heroes { get; set; }

        IDbSet<Army> Armies { get; set; }

        IDbSet<BattleLog> BattleLogs { get; set; } 
        
        IDbSet<T> Set<T>() where T : class;

        DbEntityEntry<T> Entry<T>(T entity) where T : class;

        void SaveChanges();
    }
}
