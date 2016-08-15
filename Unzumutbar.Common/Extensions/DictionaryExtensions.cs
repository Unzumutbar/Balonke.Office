using System;
using System.Collections.Generic;

namespace Unzumutbar.Extensions
{
    public static class DictionaryExtensions
    {
        public static TValue GetOrAdd<TKey, TValue>(this IDictionary<TKey, TValue> dictionary, TKey key, Func<TValue> createValueDelegate)
        {
            TValue result;
            if (!dictionary.TryGetValue(key, out result))
            {
                dictionary[key] = (result = createValueDelegate());
            }
            return result;
        }
        public static TValue GetValueOrDefault<TKey, TValue>(this IDictionary<TKey, TValue> dictionary, TKey key)
        {
            TValue result;
            dictionary.TryGetValue(key, out result);
            return result;
        }
        public static TValue GetValueOrDefault<TKey, TValue>(this IDictionary<TKey, TValue> dictionary, TKey key, TValue defaultValue)
        {
            TValue result;
            if (dictionary.TryGetValue(key, out result))
                return result;
            return defaultValue;
        }
    }
}
