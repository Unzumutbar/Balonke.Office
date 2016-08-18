using System;
using System.IO;

namespace Unzumutbar.Logging
{
    public class FileLogger : ILogger
    {
        private string _logName = "";

        public FileLogger(string logName)
        {
            _logName = logName;
            if (!File.Exists(_logName))
                File.Create(_logName).Dispose();
        }

        public void LogError(string message)
        {
            WriteLine(string.Format("ERROR|{0}", message));
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
            WriteLine(string.Format("INFO|{0}", message));
        }

        private void WriteLine(string content)
        {
            File.AppendAllText(_logName, string.Format("{0}|{1}{2}", DateTime.Now.ToString(), content, Environment.NewLine));
        }

        private void WriteEmptyLine()
        {
            File.AppendAllText(_logName, string.Format("{0}{0}", Environment.NewLine));
        }
    }
}
