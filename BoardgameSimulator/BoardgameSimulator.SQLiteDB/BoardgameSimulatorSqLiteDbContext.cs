namespace BoardgameSimulator.SQLiteDB
{
    using System.Data.Entity;
    using Models;

    public class BoardgameSimulatorSqLiteDbContext : DbContext, IBoardgameSimulatorSqLiteDbContext
    {
        public BoardgameSimulatorSqLiteDbContext()
            : base("BoardgameSimSqLiteConnection")
        {
            this.Database.CreateIfNotExists();
        }

        public IDbSet<UnitCost> UnitsCosts { get; set; }

        public new void SaveChanges()
        {
            base.SaveChanges();
        }
    }
}
