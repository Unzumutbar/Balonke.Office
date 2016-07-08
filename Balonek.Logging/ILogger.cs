using System;

namespace Balonek.Logging
{
    public interface ILogger
    {
        void LogInfo(string message);

        void LogError(string message);

        void LogError(Exception exception);
    }
}
