using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Balonek.Office.Utils
{
    public static class Enums
    {
        public enum PositionType
        {
            [Description("Einzel")]
            Single = 1,

            [Description("Regelmäßig")]
            Periodical = 2,
        };

        public enum Period
        {
            [Description("")]
            None = 0,

            [Description("Wöchentlich")]
            Weekly = 1,

            [Description("Alle zwei Wochen")]
            BiWeekly = 2,

            [Description("Alle drei Wochen")]
            TriWeekly = 3,

            [Description("Alle vier Wochen")]
            QuarterWeekly = 4,

            [Description("Monatlich")]
            Monthly = 5,
        };
    }
}
