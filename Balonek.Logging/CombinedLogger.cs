using System;

namespace Balonek.Logging
{
    public class CombinedLogger : ILogger
    {
        private ConsoleLogger consoleLog;
        private EventLogger eventLog;

        public CombinedLogger(string servicename)
        {
            consoleLog = new ConsoleLogger();
            eventLog = new EventLogger(servicename);
        }

        public void LogError(string message)
        {
            consoleLog.LogError(message);
            eventLog.LogError(message);
        }

        public void LogError(Exception exception)
        {
            var message = exception.Message;
            consoleLog.LogError(message);
            eventLog.LogError(message);
        }

        public void LogInfo(string message)
        {
            consoleLog.LogInfo(message);
            eventLog.LogInfo(message);
        }
    }
}
