namespace BoardgameSimulator.SQLiteDB
{
    using Repositories;

    public class BoardgameSimulatorSqLiteData : IBoardgameSimulatorSqLiteData
    {
        private readonly IBoardgameSimulatorSqLiteDbContext context;

        public BoardgameSimulatorSqLiteData(IBoardgameSimulatorSqLiteDbContext context)
        {
            this.context = context;

            this.UnitsCosts = new BoardgameSimulatorSqLiteUnirsCostsRepository(this.context);
        }

        public BoardgameSimulatorSqLiteData()
            : this(new BoardgameSimulatorSqLiteDbContext())
        {
        }

        public IBoardgameSimulatorSqLiteUnitsCostsRepository UnitsCosts { get; private set; }
    }
}
