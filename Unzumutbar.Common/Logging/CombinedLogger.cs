using System;

namespace Unzumutbar.Logging
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

        public void LogError(string message, Exception exception)
        {
            var combinedMessage = string.Format("{0}|{1}", message, exception.StackTrace);
            consoleLog.LogError(combinedMessage);
            eventLog.LogError(combinedMessage);
        }

        public void LogInfo(string message)
        {
            consoleLog.LogInfo(message);
            eventLog.LogInfo(message);
        }
    }
}
