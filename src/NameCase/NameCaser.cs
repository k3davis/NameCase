using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace NameCase
{
    public static class NameCaser
    {
        public static string ToNameCase(this string name)
        {
            char[] chars = name.ToCharArray();

            // build name chunks
            var chunks = new List<string>();
            var delims = new[] { '-', '.', ',' };

            string buffer = string.Empty;

            foreach (char c in chars)
            {
                if (char.IsWhiteSpace(c) || delims.Any(d => d == c))
                {
                    chunks.Add(ProcessNameCaseChunk(buffer + c));
                    buffer = string.Empty;
                }
                else
                {
                    buffer += c;
                }
            }

            chunks.Add(ProcessNameCaseChunk(buffer));

            // join the processed chunks, removing any weird whitespace
            return string.Join("", chunks).TrimWhiteSpace();
        }

        private static string ProcessNameCaseChunk(string chunk)
        {
            // surname prefixes
            if (Regex.IsMatch(chunk, @"^(van|von|der|la|d[aeio]|d[ao]s|dit)[\s,]*$", RegexOptions.IgnoreCase))
                return chunk.ToLower();

            // ordinal suffixes
            if (Regex.IsMatch(chunk, @"^M{0,4}(CM|CD|D?C{0,3})(XC|XL|L?X{0,3})(IX|IV|V?I{0,3})$", RegexOptions.IgnoreCase))
                return chunk.ToUpper();

            chunk = chunk.InitCaps();

            // second letter capitalized, like D'Angelo, McDonald, St. John, O'Neil
            if (Regex.IsMatch(chunk, @"(^|\s)+(Mc|[DO]\'|St\.|St[\.]?[\s]|Dewolf)", RegexOptions.IgnoreCase))
                return chunk.PosCaps(2);

            // third letter capitalized (common "Mac" names like MacDonald)
            if (Regex.IsMatch(chunk, @"(^|\s*)(Mac)(aul|allist|arth|b|c(abe|ann|allu|art|ask|l|or|r|ull)|d|(el|ev)|f|g|hu|i(ner|nn|nty|saa|v)|k(enn|eo|inn|n)|l(a|ea|eo|ough)|m|na[lmu]|n[eiu]|ph|q|ra|sw|ta|w)", RegexOptions.IgnoreCase))
                return chunk.PosCaps(3);

            return chunk;
        }

        private static string InitCaps(this string s)
        {
            return char.ToUpper(s[0]) + s.Substring(1).ToLower();
        }

        private static string PosCaps(this string s, int pos)
        {
            char[] chars = s.ToCharArray();

            chars[pos] = char.ToUpper(chars[pos]);

            return new string(chars);
        }

        private static string TrimWhiteSpace(this string s)
        {
            return Regex.Replace(s, @"\s+", " ").Trim();
        }
    }
}