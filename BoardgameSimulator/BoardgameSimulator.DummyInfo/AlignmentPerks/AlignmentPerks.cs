using System;
using System.Collections.Generic;
using BoardgameSimulator.DummyInfo.Skills;

namespace BoardgameSimulator.DummyInfo.AlignmentPerks
{
    public class AlignmentPerks
    {
        #region types
        private static readonly List<string> types = new List<string>
        {
            "Good",
            "Chaotic Good",
            "Chaotic Evil",
            "Lawful Evil",
            "Mythical",
            "Neutral",
            "Selfish",
            "Evil",
            "God",
            "Demigod",
            "Demon",
            "Chaotic Neutral",
            "Lawful Neutral",
            "Lawful Good"
        };
        #endregion

        #region prefixes
        private static readonly List<string> prefixes = new List<string>
        {
            "Cloak of",
            "Aura of",
            "Mantra of",
            "Virtue of",
            "Enchantment of",
            "Blessing of",
            "Shield of",
            "Power of",
            "Facet of",
            "Attunement of",
            "Shroud of",
            "Avatar of",
            "Infusion of",
            "Curse of",
            "Glyph of",
            "Rune of",
            "Song of",
            "Lament of",
            "Sigil of",
            "Boon of"
        };
        #endregion

        #region names
        private static readonly List<string> names = new List<string>
        {
            "The Gods",
            "The Sun",
            "The Moon",
            "Thorns",
            "Vampirism",
            "Bravery",
            "Immortality",
            "Mastery",
            "Death",
            "Life",
            "Fire",
            "Earth",
            "Wind",
            "Shattered Perception",
            "Mist",
            "Recovery",
            "Distraction",
            "Pain",
            "Distort",
            "Concentration",
            "Chaos",
            "Empowerment",
            "The Tides",
            "Storms",
            "Elements",
            "Resistance",
            "Swiftness",
            "Vigor",
            "Power",
            "Corruption",
            "Suffering",
            "Healing",
            "Might",
            "Torment",
            "Stability",
            "Protection",
            "Luck"
        };
        #endregion

        private static readonly double[] modifiers =
        {
            0.75, 0.8, 0.85, 0.90, 0.90, 0.90, 1.1, 1.1, 1.1, 0.95, 1, 1.05,
            1.1, 1.15, 1.2, 1.25, 1.3, 1.5
        };

        public static List<AlignmentPerk> GenerateAlignmentsList(int amount = 120)
        {
            var dictionary = new List<string>();

            var alignmentsList = new List<AlignmentPerk>();

            var rng = new Random();
            var modifLen = modifiers.Length;
            var prefLen = prefixes.Count;
            var nameLen = names.Count;

            var tLen = types.Count;

            // Feed for units sans naval and flying
            for (int i = 0; i < amount; i++)
            {
                var currentAlignmentName = string.Format("{0} {1}", prefixes[rng.Next(i * 211) % prefLen], names[rng.Next(rng.Next()) % nameLen]);

                if (!dictionary.Contains(currentAlignmentName))
                {
                    alignmentsList.Add(new AlignmentPerk(currentAlignmentName, types[rng.Next(i * 300) % tLen], modifiers[rng.Next(i * 262) % modifLen], modifiers[rng.Next(rng.Next()) % modifLen]));  
                }
            }

            return alignmentsList;
        }
    }
}
