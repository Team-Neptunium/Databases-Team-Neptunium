namespace BoardgameSimulator.MySqlDB
{
    using Repositories;
    using Telerik.OpenAccess;

    public class BoardgameSimulatorMySqlData : IBoardgameSimulatorMySqlData
    {
        private readonly BoardgameSimulatorMySqlDbContext context;

        public BoardgameSimulatorMySqlData(BoardgameSimulatorMySqlDbContext context)
        {
            this.context = context;

            this.ArmyVsArmyReports = new BoardgameSimulatorMySqlArmyVsArmyRepository(this.context);

            this.VerifyDatabase();
        }

        public BoardgameSimulatorMySqlData()
            : this(new BoardgameSimulatorMySqlDbContext())
        {
        }

        public IBoardgameSimulatorMySqlArmyVsArmyRepository ArmyVsArmyReports { get; private set; }

        private void VerifyDatabase()
        {
            var schemaHandler = context.GetSchemaHandler();
            this.EnsureDB(schemaHandler);
        }

        private void EnsureDB(ISchemaHandler schemaHandler)
        {
            string script;

            if (schemaHandler.DatabaseExists())
            {
                script = schemaHandler.CreateUpdateDDLScript(null);
            }
            else
            {
                schemaHandler.CreateDatabase();
                script = schemaHandler.CreateDDLScript();
            }

            if (!string.IsNullOrEmpty(script))
            {
                schemaHandler.ExecuteDDLScript(script);
            }
        }
    }
}
