namespace FrameworkOptionsPatternExample.Interfaces
{
    public interface ILoggingConfiguration
    {
        string MaximumLevel { get; }

        string FilePath { get; }

        string MinimumLevel { get; }

        string DatePattern { get; }
    }
}