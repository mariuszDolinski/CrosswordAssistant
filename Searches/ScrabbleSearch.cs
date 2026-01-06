using CrosswordAssistant.AppSettings;
using CrosswordAssistant.Entities.Enums;
using CrosswordAssistant.Entities.Responses;
using CrosswordAssistant.Services;

namespace CrosswordAssistant.Searches
{
    public class ScrabbleSearch : Search
    {
        public override List<string> SearchMatches(string pattern)
            => GetMatchesWithFormat(pattern, 
                (w, p) => $"{w}({ScrabbleCalculator.CountBaseScrabblePoints(w, p)})");

        public override ValidationResponse ValidatePattern(string pattern)
        {
            if (pattern.Length < 4 || pattern.Length > 15 || pattern.CountChars('.') > 2)
            {
                return new ValidationResponse(false, "Wzorzec powinien zawierać od 4 do 15 znaków, w tym co najwyżej dwa mydła");
            }
            if (!DictionaryService.ValidateAllowedChars(pattern, DictionaryService.AllowedPatternChars))
            {
                return new ValidationResponse(false, "Wzorzec zawiera niedozwolone znaki.");
            }

            return new ValidationResponse(true, "");
        }

        private static List<string> GetMatchesWithFormat(string pattern, Func<string, string, string> formatSelector)
        {
            List<string> result = [];

            foreach (var word in DictionaryService.CurrentDictionary)
            {
                if (word.Length > pattern.Length) continue;
                if (word.Length < 4 || word.Length > 14) continue;
                if (CheckForAnagram(pattern, word.ToLower()))
                {
                    result.Add(formatSelector(word, pattern));
                }
            }
            return result;
        }
    }
}
