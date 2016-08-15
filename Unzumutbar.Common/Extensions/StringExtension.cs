using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Unzumutbar.Utilities
{
    public static class StringExtension
    {
        /// <summary>
        /// Returns the number of lines in a string
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static long Lines(this string s)
        {
            long count = 1;
            int position = 0;
            while ((position = s.IndexOf('\n', position)) != -1)
            {
                count++;
                position++;         // Skip this occurance!
            }
            return count;
        }


        /// <summary>
        /// Aggregates all elements in the list with the specified separator.
        /// </summary>
        /// <typeparam name="T">Type of object the list contains</typeparam>
        /// <param name="strings">The list of strings.</param>
        /// <param name="separator">The separator.</param>
        /// <param name="keepLastSeparator">if set to <c>true</c> keep the last separator.</param>
        /// <returns></returns>
        public static string Aggregate<T>(this IEnumerable<T> strings, string separator, bool keepLastSeparator = false)
        {
            var result = strings
                .Aggregate(
                    new StringBuilder(),
                    (current, next) => current.Append(next).Append(separator))
                .ToString();

            if (keepLastSeparator || result.Length == 0)
                return result;

            return result.Substring(0, result.LastIndexOf(separator, StringComparison.OrdinalIgnoreCase));
        }

        /// <summary>
        /// Returns the specified <paramref name="number"/> of leftmost characters from <paramref name="value"/>. Equivalent to Visual FoxPro LEFT function.
        /// </summary>
        /// <param name="value">The string value</param>
        /// <param name="number">The number of characters to return</param>
        /// <returns></returns>
        public static string Left(this string value, int number)
        {
            if (value == null || value.Length <= number)
                return value;

            return value.Substring(0, number);
        }

        /// <summary>
        /// Returns the specified <paramref name="number"/> of rightmost characters from <paramref name="value"/>. Equivalent to Visual FoxPro RIGHT function.
        /// </summary>
        /// <param name="value">The string value</param>
        /// <param name="number">The number of characters to return</param>
        /// <returns>The right <paramref name="number"/> chars from value. If the <paramref name="value"/> length greater than <paramref name="number"/>, return <paramref name="value"/></returns>
        public static string Right(this string value, int number)
        {
            if (value == null || value.Length <= number)
                return value;

            return value.Substring(value.Length - number);
        }

        /// <summary>Indicates whether the specified string is null or an empty string.</summary>
        /// <param name="value">The string to test.</param>
        /// <returns>true if the value parameter is null or an empty string (""); otherwise, false.</returns>
        public static bool IsNullOrEmpty(this string value)
        {
            return String.IsNullOrEmpty(value);
        }

        /// <summary>Indicates whether the specified string is not null or a not empty string.</summary>
        /// <param name="value">The string to test.</param>
        /// <returns>true if the value parameter is not null or a not empty string (""); otherwise, false.</returns>
        public static bool IsNotNullOrEmpty(this string value)
        {
            return !String.IsNullOrEmpty(value);
        }

        /// <summary>Indicates whether the specified string is null or an empty string or whitespace.</summary>
        /// <param name="value">The string to test.</param>
        /// <returns>true if the value parameter is null or an empty string (""); otherwise, false.</returns>
        public static bool IsNullOrWhitespace(this string value)
        {
            return String.IsNullOrWhiteSpace(value);
        }

        /// <summary>Indicates whether the specified string is not null or a not empty or not whitespace string.</summary>
        /// <param name="value">The string to test.</param>
        /// <returns>true if the value parameter is not null or a not empty string (""); otherwise, false.</returns>
        public static bool IsNotNullOrWhitespace(this string value)
        {
            return !String.IsNullOrWhiteSpace(value);
        }

        /// <summary>Indicates if the specified string contains one of test values, ignoring the case.</summary>
        /// <param name="value">The string to test.</param>
        /// <param name="testValues">To values to check one of them is contained in value</param>
        /// <returns>true if one of values is contained in value; otherwise, false.</returns>
        public static bool ContainsIgnoreCase(this string value, params string[] testValues)
        {
            return value != null && testValues.Any(testValue => value.IndexOf(testValue, StringComparison.OrdinalIgnoreCase) >= 0);
        }

        /// <summary>
        /// Indicates if the specified string does not contain the value.
        /// </summary>
        /// <param name="str">The string to test.</param>
        /// <param name="value">To values to check one</param>
        /// <returns>true if value is not contained int str; otherwise, false.</returns>
        // The name of this method should be DoesNotContain, using the correct verb tense (or at least, NotContain, without s). 
        // However, as it only exists to "improve" the readability of code (instead of a ! lonely), seems more natural just include a Not.
        // Feel free to change or delete this method.
        public static bool NotContains(this string str, string value)
        {
            return !str.Contains(value);
        }
    }
}
