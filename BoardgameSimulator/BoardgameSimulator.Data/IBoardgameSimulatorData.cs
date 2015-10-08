namespace BoardgameSimulator.Data
{
    using Repositories;
    using Models;

    public interface IBoardgameSimulatorData
    {
        IGenericRepository<Army> Armies { get; }

        IGenericRepository<Unit> Units { get; }
    }
}
