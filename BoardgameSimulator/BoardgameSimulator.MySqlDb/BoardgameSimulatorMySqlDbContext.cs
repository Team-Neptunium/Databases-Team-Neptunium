namespace BoardgameSimulator.MySqlDB
{
    using Telerik.OpenAccess;
    using Telerik.OpenAccess.Metadata;

    public class BoardgameSimulatorMySqlDbContext : OpenAccessContext
    {
        // Don't touch it!
        private static string ConnectionName = "BoardgameSimMySqlConnection";

        private static readonly BackendConfiguration BackendConfig = GetBackEndConfig();

        private static readonly MetadataSource MetaDataConfig = new ModelConfiguration();

        public BoardgameSimulatorMySqlDbContext(string connectionString)
            : base(connectionString, BackendConfig, MetaDataConfig)
        {
        }

        private static BackendConfiguration GetBackEndConfig()
        {
            var config = new BackendConfiguration();

            config.Backend = "MySql";
            config.ProviderName = "MySql.Data.MySqlClient";

            return config;
        }
    }
}
