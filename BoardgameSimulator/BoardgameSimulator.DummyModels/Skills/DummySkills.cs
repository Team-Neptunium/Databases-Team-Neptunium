using System;
using System.Collections.Generic;

namespace BoardgameSimulator.DummyModels.Skills
{
    public class DummySkills
    {
        #region skill names
        private static readonly List<string> skills = new List<string>
        {
            "'To me, you beasts!'",
            "Battle Rage",
            "Body Blow",
            "Berserker Stance",
            "Cleave",
            "Charging Strike",
            "Counterattack",
            "Crippling Slash",
            "Crude Swing",
            "Decapitate",
            "Desperation Blow",
            "Final Thrust",
            "Flurry",
            "Barrage",
            "Hamstring",
            "Hundred Blades",
            "Leviathan's Sweep",
            "Power Attack",
            "Barbed Arrows",
            "Arcing Shot",
            "Barbed Trap",
            "Dust Trap",
            "Energizing Wind",
            "Feral Lunge",
            "Banishing Strike",
            "Conviction",
            "Dhuum's Attack",
            "Irresistible Sweep",
            "Thorn Cloak",
            "Mystic Twister",
            "Onslaught",
            "Pious Assault",
            "Sand Shards",
            "Twin Moon Sweep",
            "Whirling Charge",
            "Zealous Sweep",
            "Angelic Protection",
            "Blazing Finale",
            "Blazing Spear",
            "Disrupting Throw",
            "Energizing Chorus",
            "Cruel Spear",
            "Merciless Spear",
            "Vicious Attack",
            "Wearying Blow",
            "Accumulated Pain",
            "Backfire",
            "Blinding Snow",
            "Calculated Risk",
            "Chaos Storm",
            "Conjure Nightmare",
            "Cry of Pain",
            "Diversion",
            "Ether Feast",
            "Ether Nightmare",
            "Ether Phantom",
            "Frustration",
            "Power Block",
            "Power Spike",
            "Shatter Armor",
            "Shatter Storm",
            "Black Mantis Thrust",
            "Black SPider Strike",
            "Dancing Daggers",
            "Death Blossom",
            "Enduring Toxin",
            "Fox Fangs",
            "Impale",
            "Iron Palm",
            "Mantis Touch",
            "Shadow Fang",
            "Signet of Deadly Corruption",
            "Siphon Strength",
            "Unseen Fury",
            "Way of the Lotus",
            "Wild Strike",
            "Animate Flsh Golem",
            "Aura of the Lich",
            "Death Nova",
            "Deathly Chill",
            "Insidious Parasite",
            "Jagged Bones",
            "Mark of Pain",
            "Putrid Bile",
            "Putrid Explosion",
            "Soul Barbs",
            "Signet of Agony",
            "Suffering",
            "Vampiric Bite",
            "Vampiric Swarm",
            "Vile Touch",
            "Vile Miasma",
            "Ash Blast",
            "Chain Lightning",
            "Celestial Storm",
            "Crystal Wave",
            "Eruption",
            "Flame Burst",
            "Deadly Gale",
            "Gust",
            "Ice Spikes",
            "Iron Mist",
            "Lightning Hammer",
            "Maelstrom",
            "Meteor",
            "Obsidian Flame",
            "Shock",
            "Shell Shock"
        };
        #endregion

        private static readonly int[] damageAndCd =
        {
            70, 150, 80, 230, 250, 220, 450, 25, 50, 60, 320, 350, 45, 300, 275
        };

        public static List<DummySkill> GenerateSkillsList()
        {
            var skillsList = new List<DummySkill>();

            var rng = new Random();
            var dcdLen = damageAndCd.Length;

            // Feed for units sans naval and flying
            for (int i = 0; i < skills.Count; i++)
            {
                var currentSkillName = skills[i];

                skillsList.Add(new DummySkill(currentSkillName, damageAndCd[rng.Next(i * 300) % dcdLen], damageAndCd[rng.Next(i * 262) % dcdLen]));
            }

            return skillsList;
        }
    }
}
