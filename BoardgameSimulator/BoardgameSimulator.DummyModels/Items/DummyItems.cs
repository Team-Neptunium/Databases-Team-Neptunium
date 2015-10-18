using System;
using System.Collections.Generic;

namespace BoardgameSimulator.DummyModels.Items
{
    public static class DummyItems
    {
        #region names
        private static readonly List<string> itemNames = new List<string>
        {
            "Pile of Soiled Essence",
            "Pile of Putrid Essence",
            "Onyx Sliver",
            "Molten Sliver",
            "Glacial Sliver",
            "Lodestone",
            "Shard",
            "Bone Chip",
            "Tiny Claw",
            "Ancient Bone",
            "Vicious Fang",
            "Large Fang",
            "Tiny Scale",
            "Smooth Scale",
            "Armored Scale",
            "Tiny Totem",
            "Engraved Totem",
            "Intricate Totem",
            "Elaborate Totem",
            "Tiny Venom Sac",
            "Full Venom Sac",
            "Powerful Venom Sac",
            "Vial of Weak Blood",
            "Vial of Thin Blood",
            "Vial of Thick Blood",
            "Vial of Powerful Blood",
            "Sun Bead",
            "Large Skull",
            "Giant Eye",
            "Mystic Coin",
            "Charged Quartz Crystal",
            "Pristine Toxic Spore Sample",
            "Piece of Ambrite",
            "Sheet of Ambrite",
            "Sheet of Charged Ambrite",
            "Watchwork Mechanism",
            "Glob of Ectoplasm",
            "Obsidian Shard",
            "Lump of Mithrillium",
            "Deldrimor Steel Ingot",
            "Spiritwood Plank",
            "Elonian Leather Square",
            "Bolt of Damask",
            "Bloodstone Brick",
            "Dragonite Ore",
            "Dragonite Ingot",
            "Empyreal Fragment",
            "Empyreal Star",
            "Amethyst Nugget",
            "Amethyst Lump",
            "Ruby Shard",
            "Ruby Crystal",
            "Ruby Orb",
            "Chattering Skull",
            "Gibbering Skull",
            "Nougat Center",
            "Piece of Zhaitaffy"
        };
        #endregion

        public static List<DummyItem> GenerateItemsList()
        {
            var itemsList = new List<DummyItem>();

            var random = new Random();
            for (int i = 0; i < itemNames.Count; i++)
            {
                var randomIndex = random.Next(0, itemNames.Count - 1);
                var randomName = itemNames[randomIndex];
                itemsList.Add(new DummyItem(randomName, random.Next(10, 101), random.Next(20, 201)));
            }

            return itemsList;
        }
    }
}
