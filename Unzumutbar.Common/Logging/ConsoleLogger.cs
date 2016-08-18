using System;

namespace Unzumutbar.Logging
{
    public class ConsoleLogger : ILogger
    {
        public void LogError(string message)
        {
            Console.WriteLine(string.Format("ERROR|{0}", message));
        }

        public void LogError(Exception exception)
        {
            var message = exception.StackTrace;
            LogError(message);
        }

        public void LogError(string message, Exception exception)
        {
            var combinedMessage = string.Format("{0}|{1}", message, exception.StackTrace);
            LogError(combinedMessage);
        }

        public void LogInfo(string message)
        {
            Console.WriteLine(string.Format("INFO|{0}", message));
        }
    }
}
