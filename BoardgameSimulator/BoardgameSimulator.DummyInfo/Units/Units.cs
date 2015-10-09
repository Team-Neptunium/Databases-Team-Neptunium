using System;
using System.Collections.Generic;

namespace BoardgameSimulator.DummyInfo.Units
{
    public static class Units
    {
        #region unit prefixes
        private static readonly IList<string> prefixes = new List<string> { 
            "Vicious",
            "Valiant",
            "Rebelious",
            "Raging",
            "Poor",
            "Vile",
            "Foul",
            "Noble",
            "Elite",
            "Undignified",
            "Heroic",
            "Stout",
            "Foolish",
            "Wise",
            "Swift",
            "Clumsy",
            "Gifted",
            "Pious",
            "Simple",
            "Giant",
            "Tiny"
        };
        #endregion

        #region unit types
        private static readonly IList<string> unit = new List<string>
        {
            "Swordsman",
            "Brute",
            "Archer",
            "Crossbowman",
            "Balista",
            "Catapult",
            "Trebuchet",
            "Inquisitor",
            "Slinger",
            "Scout",
            "Composite Bowman",
            "Rider",
            "Berserker",
            "Samurai",
            "Cannoneer",
            "Musketeer",
            "Rifleman",
            "Siege Tower",
            "Battering Ram",
            "Pikeman",
            "Shieldmaiden",
            "Unicorn",
            "Pixie",
            "Troll",
            "Stone-hurler",
            "Nymph",
            "Druid",
            "Conjurer",
            "War Wizard",
            "Frost Priestess",
            "Shadow Adept",
            "Naga",
            "Beastmaster",
            "Knight",
            "Siren",
            "Ogre",
            "Hobgoblin",
            "Lion Rider",
            "Salamander",
            "Chimera",
            "Cerberus",
            "Boar Rider",
            "Vampire",
            "Cockatrice",
            "Harpy",
            "Minotaur",
            "Bicorn",
            "Werewolf",
            "Assassin"
        };
        #endregion

        #region naval units
        private static readonly IList<string> navalUnits = new List<string>
        {
            "Galleass",
            "Battleship",
            "Turtle ship",
            "Galley"
        };
        #endregion

        #region flying units
        private static readonly IList<string> aerialUnits = new List<string>
        {
            "Griffin",
            "Hypogriff",
            "Wyvern",
            "Flame-Breathing Dragon",
            "Pegasus",
            "Gargoyle",
            "Efreet",
            "Phoenix",
            "Black Crow"
        };
        #endregion

        #region unit suffixes
        private static readonly IList<string> suffixes = new List<string> { 
            "from Heaven",
            "of the Hills",
            "child of the Moon",
            "of the Sun",
            "of the Woods",
            "of the Lake",
            "of Avalon",
            "of the Jungle",
            "Genoese",
            "of Hell",
            "of the Skies",
            "of the Isles",
            "of the Land Beyond",
            "of the Underworld",
            "son of Scylla",
            "son of Medusa",
            "of the Vilains Team",
            "son of Anubis",
            "servant of Ra",
            "of the Order",
            "of the Coven",
            "servant of the Horned God",
            "of the Basilisk Order"
        };
        #endregion

        private static readonly int[] dmgAndHealth = { 15, 20, 25, 30, 35, 40, 45, 50, 55, 60, 65, 100, 30, 35, 40 };
        private static readonly double[] rate = { 1.5, 1.2, 1.35, 1.65, 2.2, 2, 2.5, 3.25, 3, 1.5, 1.75, 4.5, 2.35 };

        private const int aerialId = 12;
        private const int navalId = 13;

        private const int maxId = aerialId - 1;

        public static List<Unit> GenerateUnitsList(int amount = 50, ushort seed = 1234, int navalAmount = 0, int aerialAmount = 0)
        {
            var dictionary = new List<string>();

            var unitsList = new List<Unit>();

            var idRng = new Random(seed / 2);
            var unitPfRng = new Random();
            var unitTRng = new Random();
            var unitSfRng = new Random();

            var pfLen = prefixes.Count;
            var tLen = unit.Count;
            var sfLen = suffixes.Count;
            var dmgLen = dmgAndHealth.Length;
            var rateLen = rate.Length;

            // Feed for units sans naval and flying
            for (int i = 0; i < amount; i++)
            {
                var currentUnitName = string.Format("{0} {1} {2}", prefixes[unitPfRng.Next() % pfLen],
                    unit[unitTRng.Next() % tLen], suffixes[unitSfRng.Next() % sfLen]);

                if (!dictionary.Contains(currentUnitName))
                {

                    dictionary.Add(currentUnitName);
                    unitsList.Add(new Unit(currentUnitName, idRng.Next(maxId), dmgAndHealth[unitSfRng.Next(seed * 3) % dmgLen], rate[unitPfRng.Next(seed) % rateLen], dmgAndHealth[unitTRng.Next(seed * 2) % dmgLen]));
                }
            }

            for (int i = 0; i < navalAmount; i++)
            {
                var currentUnitName = string.Format("{0} {1} {2}", prefixes[unitPfRng.Next(seed) % pfLen],
                    navalUnits[unitTRng.Next(seed * 2) % navalUnits.Count], suffixes[unitSfRng.Next(seed * 3) % sfLen]);

                if (!dictionary.Contains(currentUnitName))
                {

                    dictionary.Add(currentUnitName);
                    unitsList.Add(new Unit(currentUnitName, idRng.Next(maxId), dmgAndHealth[unitSfRng.Next(seed * 3) % dmgLen], rate[unitPfRng.Next(seed) % rateLen], dmgAndHealth[unitTRng.Next(seed * 2) % dmgLen]));
                }
            }

            for (int i = 0; i < aerialAmount; i++)
            {
                var currentUnitName = string.Format("{0} {1} {2}", prefixes[unitPfRng.Next(seed) % pfLen],
                    aerialUnits[unitTRng.Next(seed * 2) % aerialUnits.Count], suffixes[unitSfRng.Next(seed * 3) % sfLen]);

                if (!dictionary.Contains(currentUnitName))
                {

                    dictionary.Add(currentUnitName);
                    unitsList.Add(new Unit(currentUnitName, idRng.Next(maxId), dmgAndHealth[unitSfRng.Next(seed * 3) % dmgLen], rate[unitPfRng.Next(seed) % rateLen], dmgAndHealth[unitTRng.Next(seed * 2) % dmgLen]));
                }
            }

            return unitsList;
        }
    }
}
