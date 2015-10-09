namespace BoardgameSimulator.DummyInfo.Heroes
{
    public class Hero
    {
        public Hero(string name, int uid, int sid)
        {
            this.Name = name;
            this.UnitId = uid;
            this.SkillId = sid;
        }

        public string Name { get; set; }

        public int UnitId { get; set; }

        public int SkillId { get; set; }
    }
}
