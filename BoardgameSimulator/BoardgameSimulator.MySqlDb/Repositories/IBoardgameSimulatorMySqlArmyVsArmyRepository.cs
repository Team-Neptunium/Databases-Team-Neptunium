namespace BoardgameSimulator.MySqlDB.Repositories
{
    using System.Collections.Generic;
    using System.Linq;
    using Models;

    public interface IBoardgameSimulatorMySqlArmyVsArmyRepository
    {
        void Add(ArmyVsArmyReport entity);

        void AddMany(IEnumerable<ArmyVsArmyReport> entities);

        void DeleteAllReports();

        IQueryable<ArmyVsArmyReport> All();

        void SaveChanges();
    }
}
