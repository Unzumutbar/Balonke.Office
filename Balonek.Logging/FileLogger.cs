using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Balonek.Logging
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

        public void LogError(Exception exception)
        {
            var message = exception.Message;
            WriteLine(string.Format("Error: {0}", message));
        }

        public void LogError(string message)
        {
            WriteLine(string.Format("Error: {0}", message));
        }

        public void LogInfo(string message)
        {
            WriteLine(string.Format("Info: {0}", message));
        }

        private void WriteLine(string content)
        {
            File.AppendAllText(_logName, string.Format("{0} {1}{2}", DateTime.Now.ToString(), content, Environment.NewLine));
        }

        private void WriteEmptyLine()
        {
            File.AppendAllText(_logName, string.Format("{0}{0}", Environment.NewLine));
        }
    }
}
