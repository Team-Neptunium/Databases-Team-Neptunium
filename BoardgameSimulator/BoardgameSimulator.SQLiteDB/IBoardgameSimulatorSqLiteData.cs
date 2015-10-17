namespace BoardgameSimulator.SQLiteDB
{
    using Repositories;

    public interface IBoardgameSimulatorSqLiteData
    {
        IBoardgameSimulatorSqLiteUnitsCostsRepository UnitsCosts { get; }
    }
}
