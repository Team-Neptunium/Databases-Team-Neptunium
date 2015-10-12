using System;
using System.Collections.Generic;

namespace BoardgameSimulator.DummyModels.Heroes
{
    public class DummyHeroes
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
            "Veteran Inquisitor",
            "Justiciar",
            "Overseer",
            "Drinkmaster",
            "Initiate",
            "Cultist",
            "Confessor"
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
            "Gandalf",
            "Ghost",
            "Bane",
            "Scythe",
            "Sacrio",
            "Abaddon",
            "Nicholas",
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
            "Apatia",
            "Mhenlo",
            "Tahlkora",
            "Lyssa",
            "Mallyx",
            "Shiro",
            "Glint",
            "Ventari",
            "Urgoz",
            "Kanaxai",
            "Apocrypha",
            "Arachni",
            "Margrid",
            "Pyre",
            "Zhed Shadowhoof",
            "Livia",
            "Gwen",
            "Zhellix",
            "Fahralon",
            "Saevio"
        };
        #endregion

        #region name suffixes
        private static readonly List<string> suffixes = new List<string>
        {
            "Filthpit",
            "The Vile",
            "The Fiend",
            "The Noble",
            "The Sly",
            "The Maligned",
            "The Mangler",
            "Breakneck",
            "Swiftspite",
            "The Quickened",
            "The Damned",
            "The Cursed",
            "The Violent",
            "The Savage",
            "The Traveler",
            "The Lazy",
            "The Heroic",
            "The Gifted",
            "The Wise",
            "The Swift",
            "Fierceshot",
            "Proelium",
            "The Zealous",
            "The Unforgiving",
            "Bloodburner",
            "Stormcaller",
            "Fleshweaver",
            "Willcrusher",
            "The Twisted"
        };
        #endregion

        private const int maxId = 220;
        private const int maxSId = 107;

        public static List<DummyHero> GenerateHeroesList(int amount = 120, ushort seed = 62523)
        {
            var dictionary = new List<string>();

            var heroesList = new List<DummyHero>();

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
                    heroesList.Add(new DummyHero(currentHeroName, unitPfRng.Next(1, maxId), unitSfRng.Next(1, unitSfRng.Next()) % maxSId));
                }
            }

            return heroesList;
        }
    }
}
