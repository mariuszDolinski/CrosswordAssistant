
using CrosswordAssistant.AppSettings;
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

        public override bool ValidatePattern(string pattern)
        {
            if (pattern.Length == 0)
            {
                MessageBox.Show("Wzorzec jest pusty.", "Błąd wzorca", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (pattern.CountChars('.') < 3)
            {
                MessageBox.Show("Wzorzec powinien zawierać conajmniej 3 kropki.", "Błąd wzorca", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            string allowedChars = AllowedLetters + ".";
            if (BaseSettings.CaseSensitive) allowedChars += AllowedLetters.ToUpper();
            foreach (var ch in pattern)
            {
                if (!allowedChars.Contains(ch))
                {
                    MessageBox.Show("Wzorzec zawiera niedozwolone znaki.", "Błąd wzorca", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }

            }
            return true;
        }
    }
}
