namespace FrameworkOptionsPatternExample.Interfaces
{
    public interface IConnectionStringConfiguration
    {
        string MyDbConnectionString { get; }

        string NsbTransportConnectionString { get; }

        string NsbPersistenceConnectionString { get; }
    }
}