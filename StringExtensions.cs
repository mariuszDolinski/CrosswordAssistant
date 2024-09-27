using System.Text;

namespace CrosswordAssistant
{
    public static class StringExtensions
    {
        /// <summary>
        /// Returns:
        /// string with replaced char at given index with given char.
        /// </summary>
        /// <param name="text"></param>
        /// <param name="index"></param>
        /// <param name="c"></param>
        /// <returns></returns>
        public static string ReplaceAtIndex(this string text, int index, char c)
        {
            StringBuilder sb = new StringBuilder(text);
            sb[index] = c;
            return sb.ToString();
        }
        /// <summary>
        /// Returns: 
        /// non-negative number indicates how many times char c appears in string (mode = 0)
        /// or how many chars in string are different than char c (mode = 1).
        /// </summary>
        /// <param name="text"></param>
        /// <param name="c"></param>
        /// <param name="mode"></param>
        /// <returns></returns>
        public static int CountChars(this string text, char c, int mode = 0)
        {
            int result = 0;
            foreach (char ch in text) 
            {
                switch(mode)
                {
                    case 0:
                        if (ch == c) result++;
                        break;
                    case 1:
                        if (ch != c) result++;
                        break;
                    default: break;
                }
            }

            return result;
        }
        /// <summary>
        /// Returns: true if string differs by exactly one character from the string given as parameter.
        /// Otherwise return false.
        /// </summary>
        /// <param name="text"></param>
        /// <param name="word"></param>
        /// <returns></returns>
        public static bool IsMetagram(this string text, string word)
        {
            if(text == null || word == null || text.Length != word.Length) return false;
            var textL = text.ToLower();
            word = word.ToLower();
            int diffCount = 0;
            for(int i = 0; i < textL.Length; i++)
            {
                if (textL[i] != word[i]) diffCount++;
                if (diffCount > 1) break;
            }

            if (diffCount == 1) return true;
            return false;
        }
        /// <summary>
        /// Returns: true if given word is formed from a string by removing one letter; false otherwise
        /// </summary>
        /// <param name="text"></param>
        /// <param name="word"></param>
        /// <returns></returns>
        public static bool DiffMinusOne(this string text, string word)
        {
            if(text.Length < 2 || text.Length != word.Length + 1) return false;
            for(int i = 0; i < text.Length; i++)
            {
                if(text.Remove(i,1) == word) return true;
            }
            return false;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="word">string in format word(<number>)</param>
        /// <returns>number from given string format</returns>
        public static int GetWordPoints(this string word)
        {
            int first = word.IndexOf('(') + 1;
            int last = word.LastIndexOf(')');
            string score = word[first..last];

            return int.Parse(score);
        }
        /// <summary>
        /// Split given pattern with coma, and check if word contains any element from that array
        /// </summary>
        /// <param name="word"></param>
        /// <param name="pattern">texts to find separated by comas</param>
        /// <returns>true if word doesn't contain any of given texts from given pattern, false otherwise</returns>
        public static bool NotContainsAny(this string word, string pattern)
        {
            if(pattern.Length == 0) return true;
            var txts = pattern.Split(',');
            foreach(var txt in txts)
            {
                if (txt.Length == 0) continue;
                if (word.Contains(txt, StringComparison.CurrentCultureIgnoreCase)) return false;
            }
            return true;
        }
        /// <summary>
        /// Add dots at the end of given word
        /// </summary>
        /// <param name="word">word to append dots</param>
        /// <param name="count">number of dotts to append</param>
        /// <returns></returns>
        public static string AppendDots(this string word, int count)
        {
            string result = word;
            for(int i = 0; i < count; i++)
            {
                result += ".";
            }
            return result;
        }
        /// <summary>
        /// Check if given word is subword, i.e. is formed form this string by removing some letters.
        /// </summary>
        /// <param name="text"></param>
        /// <param name="word"></param>
        /// <returns>true if word is a subword, false otherwise</returns>
        public static bool IsSubword(this string text, string word)
        {
            if(word.Length > text.Length) return false;
            int charindex = -1;
            for(int i = 0; i< word.Length;i++)
            {
                var ind = text.CharIndexAfterIndex(word[i], charindex + 1);
                if (ind == -1) return false;
                else charindex = ind;
            }
            return true;
        }
        /// <summary>
        /// Reports the zero-based index of the first occurence of given char from given index in this string
        /// </summary>
        /// <param name="word"></param>
        /// <param name="c">char to find</param>
        /// <param name="ind">index after which char has to be found</param>
        /// <returns>zero-based index of the first occurence of given char from given index,
        /// if given char is not present in this string after given index returns -1</returns>
        public static int CharIndexAfterIndex(this string word, char c, int ind)
        {
            int result = -1;
            
            if(ind < 0 || ind >= word.Length) return result;

            for(int i = ind; i < word.Length; i++)
            {
                if (word[i] == c) return i;
            }

            return result;
        }
    }
}
