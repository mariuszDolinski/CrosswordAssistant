using System.Diagnostics;

namespace CrosswordAssistant.Services
{
    public class Utilities
    {
        public static void SearchInWeb(string web, string searchPhrase)
        {
            ProcessStartInfo processInfo = new()
            {
                FileName = web + searchPhrase,
                UseShellExecute = true
            };
            Process.Start(processInfo);
        }

        public static List<string> BoundTo500(List<string> words)
        {
            List<string> results = words;
            if (results.Count <= 500) return results;
            return results.Take(500).ToList();
        }

        /// <summary>
        /// Check if given string contains only digits from 1 to 8, i.e. is a proper integer. 
        /// If true returns this integer. If not returns -1.
        /// </summary>
        /// <param name="pattern"></param>
        /// <returns></returns>
        public static List<int> ValidateUluzSamPattern(string pattern)
        {
            List<int> result = [];
            if (pattern.Length == 0) return result;
            if (pattern.Contains('0') || pattern.Contains('9')) return result;
            int digit;
            foreach(var ch in pattern)
            {
                if (int.TryParse(ch.ToString(), out digit))
                {
                    result.Add(digit);
                }
                else
                {
                    return [];
                }
            }
            return result;
        }

        /// <summary>
        /// Returns: list of digits of given integer.
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        public static List<int> ConvertIntToList(int number)
        {
            List<int> result = [];
            int digit;
            while (number > 0)
            {
                digit = number % 10;
                result.Insert(0, digit);
                number = (number - digit) / 10;
            }
            return result;
        }

        /// <summary>
        /// Removes empty lines and trim all lines in given list.
        /// </summary>
        /// <param name="lines"></param>
        /// <returns></returns>
        public static List<string> CorrectLines(List<string> lines)
        {
            List<string> result = [];
            foreach (string line in lines)
            {
                if(line.Length == 0) continue;
                result.Add(line.Trim());
            }
            return result;
        }
    }
}
