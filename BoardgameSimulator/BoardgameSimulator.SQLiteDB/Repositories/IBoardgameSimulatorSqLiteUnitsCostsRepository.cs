namespace BoardgameSimulator.SQLiteDB.Repositories
{
    using System;
    using System.Linq;
    using System.Linq.Expressions;
    using Models;

    public interface IBoardgameSimulatorSqLiteUnitsCostsRepository
    {
        IQueryable<UnitCost> All();

        IQueryable<UnitCost> Find(Expression<Func<UnitCost, bool>> conditions);

        void Add(UnitCost entry);

        void Delete(UnitCost entry);

        void SaveChanges();
    }
}
