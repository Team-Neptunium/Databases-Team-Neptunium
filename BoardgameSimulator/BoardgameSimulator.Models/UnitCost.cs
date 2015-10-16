namespace BoardgameSimulator.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("UnitCost")]
    public class UnitCost
    {
        [Key]
        public int Id { get; set; }

        public string UnitName { get; set; }

        public int RecruitCost { get; set; }
    }
}
