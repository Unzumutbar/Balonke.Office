using System;
using System.Windows.Forms;
using Unzumutbar.Logging;

namespace Balonek.Office.Utils
{
    public static class BalonekMessageBox
    {
        public static void ShowError(ILogger logger, Exception e)
        {
            logger.LogError(e);

            var message = string.Format("Es ist ein Fehler aufgetreten: {0}", e.StackTrace);
            MessageBox.Show(message, "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public static void Show(ILogger logger, string message)
        {
            logger.LogInfo(message);
            MessageBox.Show(message, "Hinweis", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public static void ShowStop(ILogger logger, string message)
        {
            logger.LogInfo(message);
            MessageBox.Show(message, "Hinweis", MessageBoxButtons.OK, MessageBoxIcon.Stop);
        }
    }
}
