using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace BoardgameSimulator.Models
{
    public class BattleLog
    {
        public int Id { get; set; }

        public int Army1Id { get; set; }

        [ForeignKey("Army1Id")]
        public Army Army1 { get; set; }

        public int Army2Id { get; set; }

        [ForeignKey("Army2Id")]
        public Army Army2 { get; set; }

        public DateTime Date { get; set; }
    }
}
