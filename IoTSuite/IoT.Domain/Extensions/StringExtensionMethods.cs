using System;
using System.Linq;
using System.Collections.Generic;

namespace IoT.Domain.Extensions
{
    public static class StringExtensionMethods
    {
        public static IDictionary<string, string> AzureConnectionStringToDictionary(this string valuePairString, char kvpDelimiter, char kvpSeparator)
        {
            if (string.IsNullOrWhiteSpace(valuePairString))
                throw new ArgumentException("Malformed Token");
            IEnumerable<string[]> strArays = from part in valuePairString.Split(new char[] { kvpDelimiter })
                                             select part.Split(new char[] { kvpSeparator }, 2);
            if (strArays.Any<string[]>((string[] part) => (int)part.Length != 2))
            {
                throw new FormatException("Malformed Token");
            }
            return strArays.ToDictionary<string[], string, string>((string[] kvp) => kvp[0], (string[] kvp) => kvp[1], StringComparer.OrdinalIgnoreCase);
        }
    }
}