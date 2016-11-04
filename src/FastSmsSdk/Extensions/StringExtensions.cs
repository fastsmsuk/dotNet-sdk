using System.Globalization;

namespace FastSmsSdk.Extensions
{
    internal static class StringExtensions
    {
        public static int? AsIntSafe(this string text)
        {
            int result;
            return int.TryParse(text, out result) ? result : (int?)null;
        }

        public static decimal? AsDecimalSafe(this string text)
        {
            decimal result;
            return decimal.TryParse(text, NumberStyles.Any, CultureInfo.InvariantCulture, out result) ? result : (decimal?)null;
        }

        public static string ReplaceForIndex(this string[] strings, int index)
        {
            return strings.Length > index ? strings[index].Replace("\"", string.Empty) : string.Empty;
        }
    }
}
