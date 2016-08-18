using System;
using System.Globalization;

namespace Unzumutbar.Extensions
{
    public static class DateExtensions
    {
        public static string ToMonth(this DateTime date)
        {
            var cultureInfo = CultureInfo.InvariantCulture;
            return date.ToString("MMMM", cultureInfo);
        }

        public static string ToMonth(this DateTime date, CultureInfo cultureInfo)
        {
            return date.ToString("MMMM", cultureInfo);
        }

        public static string ToMonthGerman(this DateTime date)
        {
            return date.ToString("MMMM", new CultureInfo("de-DE"));
        }

        public static string ToMonthAndYear(this DateTime date)
        {
            var cultureInfo = CultureInfo.InvariantCulture;
            return date.ToString("MMMM, yyyy", cultureInfo);
        }

        public static string ToMonthAndYear(this DateTime date, CultureInfo cultureInfo)
        {
            return date.ToString("MMMM, yyyy", cultureInfo);
        }

        public static string ToMonthAndYearGerman(this DateTime date)
        {
            return date.ToString("MMMM, yyyy", new CultureInfo("de-DE"));
        }

        public static string ToBillDate(this DateTime date)
        {
            return date.ToString("dd.MM.yyyy");
        }
    }
}
