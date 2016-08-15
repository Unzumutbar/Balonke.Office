using System;

namespace Unzumutbar.Logging
{
    public class ConsoleLogger : ILogger
    {
        public void LogError(string message)
        {
            Console.WriteLine(string.Format("Error: {0}", message));
        }

        public void LogError(Exception exception)
        {
            var message = exception.Message;
            Console.WriteLine(string.Format("Error: {0}", message));
        }

        public void LogInfo(string message)
        {
            Console.WriteLine(string.Format("Info: {0}", message));
        }
    }
}
