namespace BoardgameSimulator.DummyModels.BattleLogs
{
    using System;
    using System.Collections.Generic;

    public class DummyBattleLogs
    {
        private static Random rng = new Random();

        public static List<DummyBattleLog> GenerateBattleLogsList(int amount = 100)
        {
            var bLogList = new List<DummyBattleLog>();

            for (int i = 0; i < amount; i++)
            {
                var army1 = rng.Next(1, amount);
                var army2 = rng.Next(1, amount * 123) % amount;

                if (army1 == army2)
                {
                    i--;
                    continue;
                }

                bLogList.Add(new DummyBattleLog
                {
                    Army1Id = army1,
                    Army2Id = army2,
                    Date = GetRandomDate(DateTime.Now.AddYears(-250), DateTime.Now.AddYears(500))
                });
            }

            return bLogList;
        }

        private static DateTime GetRandomDate(DateTime from, DateTime to)
        {
            var range = to - from;

            var randTimeSpan = new TimeSpan((long)(rng.NextDouble() * range.Ticks));

            return from + randTimeSpan;
        }
    }
}
