using System;
using System.Diagnostics;

namespace Unzumutbar.Logging
{
    public class EventLogger : ILogger
    {
        private string servicename;

        public EventLogger(string servicename)
        {
            this.servicename = servicename;
        }

        public void LogInfo(string message)
        {
            EventLog.WriteEntry(this.servicename, GetMessage(message), EventLogEntryType.Information);
        }

        private string GetMessage(string message)
        {
            DateTime dt = new DateTime();
            dt = System.DateTime.UtcNow;
            message = dt.ToLocalTime() + ": " + message;
            return message;
        }

        public void LogError(string message)
        {
            EventLog.WriteEntry(this.servicename, GetMessage(message), EventLogEntryType.Error);
        }

        public void LogError(Exception exception)
        {
            var message = exception.Message;
            EventLog.WriteEntry(this.servicename, GetMessage(message), EventLogEntryType.Error);
        }

    }
}
