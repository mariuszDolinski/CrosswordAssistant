using System.Runtime.CompilerServices;
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
    }
}
