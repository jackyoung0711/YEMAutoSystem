using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using Newtonsoft.Json;

namespace JYM.Lib
{
    /// <summary>
    ///     Utilities for working with <see cref="System.String" /> type.
    /// </summary>
    public static class StringExtensions
    {
        /// <summary>
        ///     Checks if the <paramref name="source" /> contains the <paramref name="input" /> based on the provided <paramref name="comparison" /> rules.
        /// </summary>
        /// <param name="source">The source.</param>
        /// <param name="input">The input.</param>
        /// <param name="comparison">The comparison.</param>
        /// <returns><c>true</c> if [contains] [the specified source]; otherwise, <c>false</c>.</returns>
        public static bool Contains(this string source, string input, StringComparison comparison)
        {
            return source.IndexOf(input, comparison) >= 0;
        }

        /// <summary>
        ///     Checks if the <paramref name="source" /> contains the <paramref name="input" />.
        /// </summary>
        /// <param name="source">The source.</param>
        /// <param name="input">The input.</param>
        /// <returns><c>true</c> if [contains] [the specified source]; otherwise, <c>false</c>.</returns>
        public static bool Contains(this string source, string input)
        {
            return source.IndexOf(input, StringComparison.Ordinal) >= 0;
        }

        /// <summary>
        ///     A nicer way of calling <see cref="System.String.Format(string, object[])" />
        /// </summary>
        /// <param name="format">A composite format string.</param>
        /// <param name="args">An object array that contains zero or more objects to format.</param>
        /// <returns>A copy of format in which the format items have been replaced by the string representation of the corresponding objects in args.</returns>
        public static string FormatWith(this string format, params object[] args)
        {
            return string.Format(format, args);
        }

        /// <summary>
        ///     A nicer way of calling <see cref="System.String.Format(string, object[])" />
        /// </summary>
        /// <param name="format">A composite format string.</param>
        /// <param name="provider">String format provider</param>
        /// <param name="args">An object array that contains zero or more objects to format.</param>
        /// <returns>A copy of format in which the format items have been replaced by the string representation of the corresponding objects in args.</returns>
        public static string FormatWith(this string format, IFormatProvider provider, params object[] args)
        {
            return string.Format(provider, format, args);
        }

        /// <summary>
        ///     Deserialize a json string to the instance of <typeparamref name="T" />. If the <paramref name="value" /> is null or empty, <c>null</c> will be returned.
        /// </summary>
        /// <typeparam name="T">The type of the instance to deserialize from the json string.</typeparam>
        /// <param name="value">The json string .</param>
        /// <returns>The deserialized instance of <typeparamref name="T" />. If the <paramref name="value" /> is null or empty, <c>null</c> will be returned.</returns>
        public static T FromJson<T>(string value)
        {
            return value.IsNullOrEmpty() ? default(T) : JsonConvert.DeserializeObject<T>(value);
        }

        /// <summary>
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static List<string> GetListByStr(this string source)
        {
            List<string> list;
            try
            {
                string[] strs = source.Split(',');
                list = strs.ToList();
            }
            catch (Exception)
            {
                return null;
            }
            return list;
        }

        /// <summary>
        ///     A nicer way of calling the inverse of <see cref="System.String.IsNullOrEmpty(string)" />
        /// </summary>
        /// <param name="value">The string to test.</param>
        /// <returns>true if the value parameter is not null or an empty string (""); otherwise, false.</returns>
        public static bool IsNotNullOrEmpty(this string value)
        {
            return !string.IsNullOrEmpty(value);
        }

        /// <summary>
        ///     A nicer way of calling <see cref="System.String.IsNullOrEmpty(string)" />
        /// </summary>
        /// <param name="value">The string to test.</param>
        /// <returns>true if the value parameter is null or an empty string (""); otherwise, false.</returns>
        public static bool IsNullOrEmpty(this string value)
        {
            return string.IsNullOrEmpty(value);
        }

        /// <summary>
        ///     Converts a string to a Boolean (true/false) value and specifies a default value.
        /// </summary>
        /// <param name="value">The value to convert.</param>
        /// <param name="defaultValue">The value to return if <paramref name="value" /> is null or is an invalid value.</param>
        /// <returns>The converted value.</returns>
        public static bool ToBoolean(this string value, bool defaultValue = false)
        {
            bool result;
            return !bool.TryParse(value, out result) ? defaultValue : result;
        }

        /// <summary>
        ///     Converts a string to a <see cref="T:System.DateTime" /> value.
        /// </summary>
        /// <param name="value">The value to convert.</param>
        /// <returns>The converted value.</returns>
        public static DateTime ToDateTime(this string value)
        {
            return ToDateTime(value, DateTime.UtcNow);
        }

        /// <summary>
        ///     Converts a string to a <see cref="T:System.DateTime" /> value and specifies a default value.
        /// </summary>
        /// <param name="value">The value to convert.</param>
        /// <returns>The converted value.</returns>
        /// <param name="defaultValue">The value to return if <paramref name="value" /> is null or is an invalid value. The default is the minimum time value on the system.</param>
        public static DateTime ToDateTime(this string value, DateTime defaultValue)
        {
            DateTime result;
            return !DateTime.TryParse(value, out result) ? defaultValue : result;
        }

        /// <summary>
        ///     Converts a string to a <see cref="T:System.Decimal" /> number and specifies a default value.
        /// </summary>
        /// <param name="value">The value to convert.</param>
        /// <returns>The converted value.</returns>
        /// <param name="defaultValue">The value to return if <paramref name="value" /> is null or invalid.</param>
        public static decimal ToDecimal(this string value, decimal defaultValue = 0m)
        {
            decimal result;
            return !decimal.TryParse(value, out result) ? defaultValue : result;
        }

        /// <summary>
        ///     Converts a string to a <see cref="T:System.Double" /> number and specifies a default value.
        /// </summary>
        /// <param name="value">The value to convert.</param>
        /// <returns>The converted value.</returns>
        /// <param name="defaultValue">The value to return if <paramref name="value" /> is null or invalid.</param>
        public static double ToDouble(this string value, double defaultValue = 0d)
        {
            double result;
            return !double.TryParse(value, out result) ? defaultValue : result;
        }

        /// <summary>
        ///     Converts a string to a <see cref="T:System.float" /> number and specifies a default value.
        /// </summary>
        /// <param name="value">The value to convert.</param>
        /// <param name="defaultValue">The value to return if <paramref name="value" /> is null or is an invalid value.</param>
        /// <returns>The converted value.</returns>
        [SuppressMessage("Microsoft.Naming", "CA1720:IdentifiersShouldNotContainTypeNames", MessageId = "float")]
        public static float ToFloat(this string value, float defaultValue = 0.0f)
        {
            float result;
            return !float.TryParse(value, out result) ? defaultValue : result;
        }

        /// <summary>
        ///     Converts a string to a <see cref="T:System.Guid" /> number and specifies a default value.
        /// </summary>
        /// <param name="value">The value to convert.</param>
        /// <param name="format">The format of the value.</param>
        /// <param name="defaultValue">The value to return if <paramref name="value" /> is null or invalid.</param>
        /// <returns>The converted value.</returns>
        public static Guid ToGuid(this string value, string format = "N", Guid? defaultValue = null)
        {
            Guid result;
            return !Guid.TryParseExact(value, format, out result) ? defaultValue.GetValueOrDefault(Guid.Empty) : result;
        }

        /// <summary>
        ///     Converts a string to to a <see cref="T:System.int" /> number and specifies a default value.
        /// </summary>
        /// <param name="value">The value to convert.</param>
        /// <param name="defaultValue">The value to return if <paramref name="value" /> is null or is an invalid value.</param>
        /// <returns>The converted value.</returns>
        [SuppressMessage("Microsoft.Naming", "CA1720:IdentifiersShouldNotContainTypeNames", MessageId = "int")]
        public static int ToInt(this string value, int defaultValue = 0)
        {
            int result;
            return !int.TryParse(value, out result) ? defaultValue : result;
        }

        /// <summary>
        ///     Converts a string to to a <see cref="T:System.int" /> number and specifies a default value.
        /// </summary>
        /// <param name="value">The value to convert.</param>
        /// <param name="defaultValue">The value to return if <paramref name="value" /> is null or is an invalid value.</param>
        /// <returns>The converted value.</returns>
        public static short ToInt16(this string value, short defaultValue = 0)
        {
            short result;
            return !short.TryParse(value, out result) ? defaultValue : result;
        }

        /// <summary>
        ///     Converts a string to to a <see cref="T:System.int" /> number and specifies a default value.
        /// </summary>
        /// <param name="value">The value to convert.</param>
        /// <param name="defaultValue">The value to return if <paramref name="value" /> is null or is an invalid value.</param>
        /// <returns>The converted value.</returns>
        public static int ToInt32(this string value, int defaultValue = 0)
        {
            int result;
            return !int.TryParse(value, out result) ? defaultValue : result;
        }

        /// <summary>
        ///     Converts a string to to a <see cref="T:System.int" /> number and specifies a default value.
        /// </summary>
        /// <param name="value">The value to convert.</param>
        /// <param name="defaultValue">The value to return if <paramref name="value" /> is null or is an invalid value.</param>
        /// <returns>The converted value.</returns>
        public static long ToInt64(this string value, long defaultValue = 0)
        {
            long result;
            return !long.TryParse(value, out result) ? defaultValue : result;
        }

        /// <summary>
        ///     Transforms an object into a json string representation. When the value is a null reference, the nullValue will be returned.
        /// </summary>
        /// <param name="value">The value to be transformed.</param>
        /// <param name="nullValue">The string to return when the value is a null reference.Default is null</param>
        /// <returns>A string representation of the supplied <paramref name="value" />.</returns>
        public static string ToJson(this object value, string nullValue = null)
        {
            if (value == null)
            {
                return nullValue;
            }
            try
            {
                return JsonConvert.SerializeObject(value);
            }
            catch
            {
                return value.ToString();
            }
        }

        /// <summary>
        ///     Converts a string to to a <see cref="T:System.int" /> number and specifies a default value.
        /// </summary>
        /// <param name="value">The value to convert.</param>
        /// <param name="defaultValue">The value to return if <paramref name="value" /> is null or is an invalid value.</param>
        /// <returns>The converted value.</returns>
        public static long ToLong(this string value, long defaultValue = 0L)
        {
            long result;
            return !long.TryParse(value, out result) ? defaultValue : result;
        }
    }
}