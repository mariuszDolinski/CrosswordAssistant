using CrosswordAssistant.Entities;
using System.ComponentModel.Design;
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
        /// Removes empty lines and trim all lines in given list.
        /// </summary>
        /// <param name="lines"></param>
        /// <returns></returns>
        public static List<string> CorrectLines(List<string> lines)
        {
            List<string> result = [];
            foreach (string line in lines)
            {
                var tLine = line.Trim();
                if(tLine.Length == 0) continue;
                result.Add(tLine);
            }
            return result;
        }

    }
}
