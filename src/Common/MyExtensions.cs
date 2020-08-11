using System;
using System.Collections.Generic;

namespace Common
{
    public static partial class MyExtensions
    {
        public static bool MyEquals(this string value, string value2, StringComparison comparison = StringComparison.OrdinalIgnoreCase)
        {
            var valueFix = string.Empty;
            if (!string.IsNullOrWhiteSpace(value))
            {
                valueFix = value.Trim();
            }

            var value2Fix = string.Empty;
            if (!string.IsNullOrWhiteSpace(value2))
            {
                value2Fix = value2.Trim();
            }

            return valueFix.Equals(value2Fix, comparison);
        }

        public static bool MyContains(this IEnumerable<string> values, string toCheck, StringComparison comparison = StringComparison.OrdinalIgnoreCase)
        {
            foreach (var value in values)
            {
                if (value.MyEquals(toCheck, comparison))
                {
                    return true;
                }
            }
            return false;
        }

        public static string MyFind(this IEnumerable<string> values, string toCheck, StringComparison comparison = StringComparison.OrdinalIgnoreCase)
        {
            foreach (var value in values)
            {
                if (value.MyEquals(toCheck, comparison))
                {
                    return value;
                }
            }
            return null;
        }

        public static IDictionary<string, object> MySet(this IDictionary<string, object> dictionary, string key, object value)
        {
            if (dictionary == null) throw new ArgumentNullException(nameof(dictionary));
            dictionary[key] = value;
            return dictionary;
        }

        public static T MyGetIf<T>(this IDictionary<string, object> dictionary, string key, T defaultValue, bool setIfNotExist = false)
        {
            if (dictionary == null) throw new ArgumentNullException(nameof(dictionary));

            if (dictionary.ContainsKey(key))
            {
                return (T)dictionary[key];
            }

            if (!setIfNotExist)
            {
                return defaultValue;
            }

            dictionary[key] = defaultValue;
            return defaultValue;
        }
    }
}
