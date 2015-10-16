namespace BoardgameSimulator.SQLiteDB
{
    using System;
    using System.Linq;
    using Data;
    using Models;

    public class SqLiteDataSeeder
    {
        public static void Seed(int entries = 100)
        {
            var data = new BoardgameSimulatorSqLiteData();

            var oldEntries = data.UnitsCosts.All();

            foreach (var entry in oldEntries)
            {
                data.UnitsCosts.Delete(entry);
            }

            var random = new Random();

            var sqldata = new BoardgameSimulatorData();

            var unitNames = sqldata.Units.All().Select(u => u.Name).ToList();

            foreach (var unit in unitNames)
            {
                var randomNumber = random.Next(150, 3500);

                data.UnitsCosts.Add(new UnitCost
                {
                    UnitName = unit,
                    RecruitCost = randomNumber
                });
            }

            data.UnitsCosts.SaveChanges();
        }
    }
}
