namespace BoardgameSimulator.Models
{
    public class AlignmentPerk
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public AlignmentType Type { get; set; }

        public double HealthMultiplier { get; set; }

        public double DamageMultiplier { get; set; }
    }
}
