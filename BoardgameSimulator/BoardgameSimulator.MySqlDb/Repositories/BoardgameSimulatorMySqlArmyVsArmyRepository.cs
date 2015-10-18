namespace BoardgameSimulator.MySqlDB.Repositories
{
    using System.Collections.Generic;
    using System.Linq;
    using Models;

    public class BoardgameSimulatorMySqlArmyVsArmyRepository : IBoardgameSimulatorMySqlArmyVsArmyRepository
    {
        private readonly BoardgameSimulatorMySqlDbContext context;

        public BoardgameSimulatorMySqlArmyVsArmyRepository(BoardgameSimulatorMySqlDbContext context)
        {
            this.context = context;
        }

        public void Add(ArmyVsArmyReport entity)
        {
            this.context.Add(entity);
        }

        public void AddMany(IEnumerable<ArmyVsArmyReport> entities)
        {
            this.context.Add(entities);
        }

        public void DeleteAllReports()
        {
            this.context.Delete(this.All());
        }

        public IQueryable<ArmyVsArmyReport> All()
        {
            return this.context.GetAll<ArmyVsArmyReport>();
        }

        public void SaveChanges()
        {
            this.context.SaveChanges();
        }
    }
}
