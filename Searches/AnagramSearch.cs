
using CrosswordAssistant.AppSettings;
using CrosswordAssistant.Entities.Responses;
using CrosswordAssistant.Services;

namespace CrosswordAssistant.Searches
{
    public class AnagramSearch : Search
    {
        /// <summary>
        /// Search or anagrams of given pattern. Dot (.) replace any letter.
        /// </summary>
        /// <param name="pattern"></param>
        /// <returns>list of words from CurrentDictionary which contains excatly the same letters
        /// as in pattern.</returns>
        public override List<string> SearchMatches(string pattern)
        {
            List<string> result = [];

            foreach (var word in DictionaryService.CurrentDictionary)
            {
                if (word is null) continue;
                if (word.Length != pattern.Length) continue;
                if (word.Equals(pattern)) continue;
                if (CheckForAnagram(pattern, word))
                {
                    result.Add(word);
                }
            }

            return result;
        }

        public override ValidationResponse ValidatePattern(string pattern)
        {
            if (pattern.Length == 0)
            {
                return new ValidationResponse(false, "Wzorzec jest pusty.");
            }
            string allowedChars = AllowedLetters + ".";
            if (BaseSettings.CaseSensitive) allowedChars += AllowedLetters.ToUpper();
            foreach (var ch in pattern)
            {
                if (!allowedChars.Contains(ch))
                {
                    return new ValidationResponse(false, "Wzorzec zawiera niedozwolone znaki.");
                }
            }
            return new ValidationResponse(true, "");
        }
    }
}
