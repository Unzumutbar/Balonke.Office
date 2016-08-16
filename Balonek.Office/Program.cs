using Balonek.Office.Forms;
using System;
using System.IO;
using System.Windows.Forms;
using Unzumutbar.Logging;

namespace Balonek.Office
{
    static class Program
    {
        public static string AppDirectory = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
        public static Database.Database Database;
        public static ILogger Logger;
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            var logFile = Path.Combine(AppDirectory, "BalonekOfficeLog.txt");
            Logger = new FileLogger(logFile);
            Logger.LogInfo("Application Balonek Office started");
            Database = new Database.Database(AppDirectory, Logger);

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }
    }
}
