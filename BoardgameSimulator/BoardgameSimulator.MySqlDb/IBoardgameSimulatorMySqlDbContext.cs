namespace BoardgameSimulator.MySqlDB
{
    using System;
    using System.Reflection;
    using Telerik.OpenAccess;
    using Telerik.OpenAccess.Metadata;

    public class BoardgameSimulatorMySqlDbContext : OpenAccessContext
    {
        public BoardgameSimulatorMySqlDbContext(string connectionString, BackendConfiguration backendConfiguration, MetadataSource metadataSource) : base(connectionString, backendConfiguration, metadataSource)
        {
        }
    }
}
