using System.Collections.Generic;
using UniRx;

namespace Utils
{
    public static class DictionaryExtensions
    {
        public static void SetIfNotChanged<TK, TV>(this IDictionary<TK, TV> dictionary, TK key, TV value)
        {
            if(Equals(dictionary[key], value)) return;
            dictionary[key] = value;
        }
    }
}