using BoardgameSimulator.MongoDB;

namespace BoardgameSimulator.ConsoleApp
{
    using Data;

    public class ConsoleApp
    {
        public static void Main()
        {
            const string mongoDbName = "boardgamesimulatormongodb";

            var data = new BoardgameSimulatorData(new BoardgameSimulatorDbContext());

            var mongoConnection = new MongoConnection();

            mongoConnection.Connect(mongoDbName);
        }
    }
}
