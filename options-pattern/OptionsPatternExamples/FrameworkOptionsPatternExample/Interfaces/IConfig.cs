using System;

namespace FrameworkOptionsPatternExample.Interfaces
{
    public interface IConfig
    {
        string MyString { get; }

        int MyNumber { get; }

        Uri MyUri { get; }

        bool MyBoolThatMustBeDefined { get; }

        string MyIpAddress { get;  }

        ILoggingConfiguration LoggingConfiguration { get; }
    }
}