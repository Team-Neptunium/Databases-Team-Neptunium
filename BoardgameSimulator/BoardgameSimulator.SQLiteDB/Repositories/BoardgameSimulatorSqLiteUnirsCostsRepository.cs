namespace BoardgameSimulator.SQLiteDB.Repositories
{
    using System;
    using System.Linq;
    using System.Linq.Expressions;
    using Models;

    public class BoardgameSimulatorSqLiteUnirsCostsRepository : IBoardgameSimulatorSqLiteUnitsCostsRepository
    {
        private readonly IBoardgameSimulatorSqLiteDbContext context;

        public BoardgameSimulatorSqLiteUnirsCostsRepository(IBoardgameSimulatorSqLiteDbContext context)
        {
            this.context = context;
        }

        public IQueryable<UnitCost> All()
        {
            return this.context.UnitsCosts.AsQueryable();
        }

        public IQueryable<UnitCost> Find(Expression<Func<UnitCost, bool>> conditions)
        {
            return this.All().Where(conditions);
        }

        public void Add(UnitCost entry)
        {
            this.context.UnitsCosts.Add(entry);
        }

        public void Delete(UnitCost entry)
        {
            this.context.UnitsCosts.Remove(entry);
        }

        public void SaveChanges()
        {
            this.context.SaveChanges();
        }
    }
}
