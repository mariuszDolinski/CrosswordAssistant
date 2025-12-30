
using CrosswordAssistant.AppSettings;
using CrosswordAssistant.Services;
using System.Text.RegularExpressions;

namespace CrosswordAssistant.Searches
{
    public class WordsFromWordSearch : Search
    {
        public override List<string> SearchMatches(string pattern)
        {
            List<string> result = [];
            string regexPattern = regexStart + "[";

            foreach(var c in pattern)
            {
                regexPattern += c;
            }

            regexPattern += "]*$";

            if (BaseSettings.CaseSensitive)
            {
                foreach (var word in DictionaryService.CurrentDictionary)
                {
                    if (word.Length < 3) continue;
                    if (Regex.IsMatch(word, regexPattern))
                    {
                        result.Add(word);
                    }
                }
            }
            else
            {
                foreach (var word in DictionaryService.CurrentDictionary)
                {
                    if (word.Length < 3) continue;
                    if (Regex.IsMatch(word, regexPattern, RegexOptions.IgnoreCase))
                    {
                        result.Add(word);
                    }
                }
            }
            return result;
        }
    }
}
