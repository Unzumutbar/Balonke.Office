using System;

namespace Balonek.Office.Utils
{
    public static class StaticStrings
    {
        public static string ErrorMessage(Exception e)
        {
            return string.Format("Es ist ein Fehler aufgetreten: {0}", e.StackTrace);
        }
    }
}
