using System.Collections.Generic;

namespace FakeVader.Core.Extensions {
    public static class StringExtensions {
        public static bool IsNotNullOrEmpty(this string str) {
            return !string.IsNullOrEmpty(str);
        }

        public static bool IsNullOrEmpty(this string str) {
            return string.IsNullOrEmpty(str);
        }

        public static string Join(this IEnumerable<string> strings, string seperator) {
            return string.Join(seperator, strings);
        }
    }
}