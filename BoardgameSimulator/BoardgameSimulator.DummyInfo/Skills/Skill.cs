namespace BoardgameSimulator.DummyInfo.Skills
{
    public class Skill
    {
        public Skill(string name, int dmg, int cd)
        {
            this.Name = name;
            this.Damage = dmg;
            this.Cooldown = cd;
        }

        public string Name { get; set; }

        public int Damage { get; set; }

        public int Cooldown { get; set; }
    }
}
