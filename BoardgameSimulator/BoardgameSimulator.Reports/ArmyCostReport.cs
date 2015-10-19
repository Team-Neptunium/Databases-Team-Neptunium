namespace BoardgameSimulator.Reports
{
    using System;

    public class ArmyCostReport
    {
        public int Army1Id { get; set; }

        public string UnitName1 { get; set; }

        public int UnitQuantity1 { get; set; }

        public int UnitCost1 { get; set; }

        public int Army2Id { get; set; }

        public string UnitName2 { get; set; }

        public int UnitQuantity2 { get; set; }

        public int UnitCost2 { get; set; }

        public DateTime Date { get; set; }
    }
}
