namespace BoardgameSimulator.MySqlDB
{
    using Repositories;

    public interface IBoardgameSimulatorMySqlData
    {
        IBoardgameSimulatorMySqlArmyVsArmyRepository ArmyVsArmyReports { get; }
    }
}
