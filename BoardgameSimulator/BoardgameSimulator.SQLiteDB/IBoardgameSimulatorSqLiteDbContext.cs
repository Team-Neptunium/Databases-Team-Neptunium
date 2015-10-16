namespace BoardgameSimulator.SQLiteDB
{
    using System.Data.Entity;
    using Models;

    public interface IBoardgameSimulatorSqLiteDbContext
    {
        IDbSet<UnitCost> UnitsCosts { get; }

        void SaveChanges();
    }
}
