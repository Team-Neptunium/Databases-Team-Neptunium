namespace BoardgameSimulator.MySqlDB
{
    using System;
    using Repositories;
    using Telerik.OpenAccess;

    public class BoardgameSimulatorMySqlData : IBoardgameSimulatorMySqlData
    {
        private const string ConnectionString = "server=localhost;database=boardgamesimulator;uid=root;pwd={0};";

        private readonly BoardgameSimulatorMySqlDbContext context;
        
        public BoardgameSimulatorMySqlData()
        {
            var password = MySqlPwdPrompt();

            this.context = new BoardgameSimulatorMySqlDbContext(string.Format(ConnectionString, password));

            this.ArmyVsArmyReports = new BoardgameSimulatorMySqlArmyVsArmyRepository(this.context);

            this.VerifyDatabase();
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

        private string MySqlPwdPrompt()
        {
            Console.WriteLine("Attempting to connect to local MySql Server...");
            Console.Write("Please enter your password for 'root' account: ");
            Console.ForegroundColor = Console.BackgroundColor;
            var pwd = Console.ReadLine().Trim();
            Console.ResetColor();

            return pwd;
        }
    }
}
