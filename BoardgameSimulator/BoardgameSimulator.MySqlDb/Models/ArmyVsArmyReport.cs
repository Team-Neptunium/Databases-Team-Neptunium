namespace BoardgameSimulator.MySqlDB.Models
{
    public class ArmyVsArmyReport
    {
        public int Id { get; set; }

        public int Army1Id { get; set; }

        public string UnitName1 { get; set; }

        public int UnitQuantity1 { get; set; }

        public int Army2Id { get; set; }

        public string UnitName2 { get; set; }

        public int UnitQuantity2 { get; set; }
    }
}
