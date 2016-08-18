using System;

namespace Unzumutbar.Logging
{
    public interface ILogger
    {
        void LogInfo(string message);

        void LogError(string message);

        void LogError(Exception exception);

        void LogError(string message, Exception exception);
    }
}
