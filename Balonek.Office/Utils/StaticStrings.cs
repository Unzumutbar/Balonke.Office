using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
