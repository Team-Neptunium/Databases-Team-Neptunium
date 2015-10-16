namespace BoardgameSimulator.SQLiteDB
{
    using Models;

    public class Program
    {
        static void Main()
        {
            var sqliteData = new BoardgameSimulatorSqLiteData();

            sqliteData.UnitsCosts.Add(new UnitCost
            {
                UnitName = "Pesho the Valiant",
                RecruitCost = 3000
            });

            sqliteData.UnitsCosts.SaveChanges();
        }
    }
}
