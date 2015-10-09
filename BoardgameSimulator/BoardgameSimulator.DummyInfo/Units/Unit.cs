namespace BoardgameSimulator.DummyInfo.Units
{
    public class Unit
    {
        public Unit(string name, int type, int damage, double rate, int hp)
        {
            this.Name = name;
            this.AttackType = type;
            this.Damage = damage;
            this.AttackRate = rate;
            this.Health = hp;
        }

        public string Name { get; set; }
        public int AttackType { get; set; }
        public int Damage { get; set; }
        public double AttackRate { get; set; }
        public int Health { get; set; }
    }
}
