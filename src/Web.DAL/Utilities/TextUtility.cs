using System.Text.RegularExpressions;

namespace Web.DAL.Utilities
{
    public static partial class TextUtility
    {
        [GeneratedRegex(@"[^a-zA-Z0-9]+", RegexOptions.Compiled)]
        private static partial Regex Separators();

        public static string[] SplitText(string content)
        {
            return Separators().Split(content);
        }
    }
}
