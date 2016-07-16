using System;

namespace Balonek.Office.Utils
{
    public static class DateExtensions
    {
        public static string ToMonth(this DateTime date)
        {
            return date.ToString("MMMM");
        }

        public static string ToMonthAndYear(this DateTime date)
        {
            return date.ToString("MMMM, yyyy");
        }

        public static string ToBillDate(this DateTime date)
        {
            return date.ToString("dd.MM.yyyy");
        }
    }
}
