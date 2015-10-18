namespace BoardgameSimulator.MySqlDB
{
    using System;
    using Telerik.OpenAccess;

    class Program
    {
        static void Main()
        {
            UpdateDatabase();
        }

        private static void UpdateDatabase()
        {
            var context = new BoardgameSimulatorMySqlDbContext();

            var schemaHandler = context.GetSchemaHandler();
            EnsureDB(schemaHandler);
        }

        private static void EnsureDB(ISchemaHandler schemaHandler)
        {
            string script = null;

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
