using System;
using System.Globalization;

namespace Balonek.Office.Utils
{
    public static class DateExtensions
    {
        public static string ToMonth(this DateTime date)
        {
            return date.ToString("MMMM", new CultureInfo("de-DE"));
        }

        public static string ToMonthAndYear(this DateTime date)
        {
            return date.ToString("MMMM, yyyy", new CultureInfo("de-DE"));
        }

        public static string ToBillDate(this DateTime date)
        {
            return date.ToString("dd.MM.yyyy");
        }
    }
}
