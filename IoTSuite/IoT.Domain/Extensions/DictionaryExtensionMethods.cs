using System.Collections.Generic;

namespace IoT.Domain.Extensions
{
    public static class DictionaryExtensionMethods
    {
        public static string GetValueOrDefault(this IDictionary<string, string> map, string keyName)
        {
            string str;
            if (!map.TryGetValue(keyName, out str))
            {
                str = null;
            }
            return str;
        }
    }
}