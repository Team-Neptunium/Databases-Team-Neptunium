namespace BoardgameSimulator.ConsoleApp
{
    using Data;

    public class ConsoleApp
    {
        public static void Main()
        {
            var data = new BoardgameSimulatorData(new BoardgameSimulatorDbContext());
        }
    }
}
