using CrosswordAssistant.AppSettings;
using CrosswordAssistant.Services;
using System.Text.RegularExpressions;

namespace CrosswordAssistant.Searches
{
    public class PatternSearch : Search
    {
        /// <summary>
        /// Search words which match given pattern.
        /// Dot (.) replace any letter.
        /// </summary>
        /// <param name="pattern"></param>
        /// <returns>list of words from CurrentDictionary which match given pattern. </returns>
        public override List<string> SearchMatches(string pattern)
        {
            List<string> result = [];
            string regexPattern = "^";

            foreach (var ch in pattern)
            {
                if (ch == '.') regexPattern += "[a-ząćęńóśłżźA-ZĄĆĘŃÓŚŻŹ]";
                else if (ch == '?') regexPattern += "[a-ząćęńóśłżźA-ZĄĆĘŃÓŚŻŹ]+";
                else regexPattern += ch;
            }
            regexPattern += "$";
            if (BaseSettings.CaseSensitive)
            {
                foreach (var word in DictionaryService.CurrentDictionary)
                {
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
                    if (Regex.IsMatch(word, regexPattern, RegexOptions.IgnoreCase))
                    {
                        result.Add(word);
                    }
                }
            }
            return result;
        }

        public override ValidateResult ValidatePattern(string pattern)
        {
            if (pattern.Length == 0)
            {
                return new ValidateResult(false, "Wzorzec jest pusty.");
            }
            string allowedChars = AllowedLetters + ".?";
            if (BaseSettings.CaseSensitive) allowedChars += AllowedLetters.ToUpper();
            foreach (var ch in pattern)
            {
                if (!allowedChars.Contains(ch))
                {
                    return new ValidateResult(false, "Wzorzec zawiera niedozwolone znaki.");
                }
                    
            }
            return new ValidateResult(true, "");
        }
    }
}
