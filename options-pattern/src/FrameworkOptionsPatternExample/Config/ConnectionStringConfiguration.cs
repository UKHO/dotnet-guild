using FrameworkOptionsPatternExample.Interfaces;
using System.Configuration;

namespace FrameworkOptionsPatternExample.Config
{
    public class ConnectionStringConfiguration : IConnectionStringConfiguration
    {
        public string MyDbConnectionString => ConfigurationManager.ConnectionStrings["MyDb"].ConnectionString;

        public string NsbTransportConnectionString =>
            ConfigurationManager.ConnectionStrings["NServiceBus/Transport"].ConnectionString;

        public string NsbPersistenceConnectionString =>
            ConfigurationManager.ConnectionStrings["NServiceBus/Persistence"].ConnectionString;
    }
}