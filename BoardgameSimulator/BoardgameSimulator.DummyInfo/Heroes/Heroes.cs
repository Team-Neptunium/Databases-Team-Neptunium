using System;
using System.Collections.Generic;
using BoardgameSimulator.DummyInfo.Units;

namespace BoardgameSimulator.DummyInfo.Heroes
{
    public class Heroes
    {
        #region prefixes

        private static readonly List<string> prefixes = new List<string>
        {
            "Dangerous",
            "Deadly",
            "Resistant",
            "Wealthy",
            "Tiny",
            "Fragile",
            "Heavy",
            "Admiral",
            "Demolitionist",
            "Crusader",
            "Ambassador",
            "Captain",
            "Deadeye",
            "Exemplar",
            "Explorer",
            "Champion",
            "Agent",
            "Lieutenant",
            "General",
            "High Priest",
            "Minister",
            "Magister",
            "Inquisitor",
            "Siegemaster",
            "Scholar",
            "Warmaster",
            "Veteran Inquisitor"
        };
        #endregion

        #region names
        private static readonly List<string> names = new List<string>
        {
            "Tybalt",
            "Wynne",
            "Nizoon",
            "Sierra",
            "Scylla",
            "Tyrant",
            "Xiar",
            "Zuul",
            "Grule",
            "Levona",
            "Lady",
            "Faustus",
            "Fade",
            "Bane",
            "Scythe",
            "Sacrio",
            "Timok",
            "Richard",
            "Lucard",
            "Kahlan",
            "Nicci",
            "Sansha",
            "Rayne",
            "Kerrigan",
            "Rahl",
            "Rhendak",
            "Stravig",
            "Brann",
            "Jansen",
            "Syrine",
            "Rhinart",
            "Dinky",
            "Apatia"
        };
        #endregion

        #region name suffixes
        private static readonly List<string> suffixes = new List<string>
        {
            "Filthpit",
            "The Vile",
            "The Fiend",
            "The Noble",
            "The Maligned",
            "The Mangler",
            "Breakneck",
            "Swiftspite",
            "The Quickened",
            "The Damned",
            "The Cursed",
            "The Violent",
            "The Savage",
            "The Lazy",
            "The Heroic",
            "The Gifted",
            "The Wise",
            "The Swift"
        };
        #endregion

        private const int maxId = 101;

        public static List<Hero> GenerateHeroesList(int amount = 120, ushort seed = 62523)
        {
            var dictionary = new List<string>();

            var heroesList = new List<Hero>();

            var unitPfRng = new Random();
            var unitNRng = new Random();
            var unitSfRng = new Random();

            var pfLen = prefixes.Count;
            var nLen = names.Count;
            var sfLen = suffixes.Count;

            // Feed for units sans naval and flying
            for (int i = 0; i < amount; i++)
            {
                var currentHeroName = string.Format("{0} {1} {2}", prefixes[unitPfRng.Next(seed) % pfLen],
                    names[unitNRng.Next(seed/2) % nLen], suffixes[unitSfRng.Next(seed/21) % sfLen]);

                if (!dictionary.Contains(currentHeroName))
                {
                    dictionary.Add(currentHeroName);
                    heroesList.Add(new Hero(currentHeroName, unitPfRng.Next(1, maxId), unitSfRng.Next(1, unitSfRng.Next())%maxId));
                }
            }

            return heroesList;
        }
    }
}
