namespace BoardgameSimulator.MySqlDB
{
    using Telerik.OpenAccess;
    using Telerik.OpenAccess.Metadata;

    public class BoardgameSimulatorMySqlDbContext : OpenAccessContext
    {
        private static string ConnectionString = "BoardgameSimMySqlConnection";

        private static readonly BackendConfiguration BackendConfig = GetBackEndConfig();

        private static readonly MetadataSource MetaDataConfig = new ModelConfiguration();

        public BoardgameSimulatorMySqlDbContext(string connectionString, BackendConfiguration backendConfiguration, MetadataSource metadataSource)
            : base(connectionString, backendConfiguration, metadataSource)
        {
        }

        public BoardgameSimulatorMySqlDbContext()
            : this(ConnectionString, BackendConfig, MetaDataConfig)
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
