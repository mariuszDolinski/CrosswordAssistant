using CrosswordAssistant.AppSettings;
using CrosswordAssistant.Entities.Responses;
using CrosswordAssistant.Services;
using System.Text;

namespace CrosswordAssistant.Searches
{
    public class WordInWordSearch : Search
    {
        public override List<string> SearchMatches(string pattern)
        {
            List<string> result = [];

            var patternSearch = new PatternSearch();
            var preResult = patternSearch.SearchMatches(pattern);

            foreach (var word in preResult) 
            { 
                var wordBuilder = new StringBuilder(word);
                for (int i = 0; i < word.Length; i++) 
                {
                    if (pattern[i] != '.')
                    {
                        wordBuilder[i] = '-';
                    }
                }
                var match = wordBuilder.ToString().Replace("-", "");
                if (DictionaryService.CurrentDictionary.Contains(match))
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
                return new ValidationResponse(false, "Wzorzec jest pusty");
            }
            if (pattern.CountChars('.') < 3)
            {
                return new ValidationResponse(false, "Wzorzec powinien zawierać conajmniej 3 kropki.");
            }
            string allowedChars = AllowedLetters + ".";
            if (BaseSettings.CaseSensitive) allowedChars += AllowedLetters.ToUpper();
            foreach (var ch in pattern)
            {
                if (!allowedChars.Contains(ch))
                {
                    MessageBox.Show("Wzorzec zawiera niedozwolone znaki.", "Błąd wzorca", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return new ValidationResponse(false, "Wzorzec zawiera niedozwolone znaki.");

                }
            }
            return new ValidationResponse(true, "");
        }
    }
}
