using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace FakeAGS.Engine
{
    public static class Wildcard
    {
        public static string WildcardToRegex(string pattern)
        {
            return "^" + Regex.Escape(pattern)
                              .Replace(@"\*", ".*")
                              .Replace(@"\?", ".")
                       + "$";
        }

        public static bool Matches(string wildcard, string value)
        {
            return Regex.IsMatch(value, WildcardToRegex(wildcard));

        }
    }
}
