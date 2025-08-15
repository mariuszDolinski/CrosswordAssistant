
using CrosswordAssistant.AppSettings;
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

        public override bool ValidatePattern(string pattern)
        {
            if (pattern.Length == 0)
            {
                MessageBox.Show("Wzorzec jest pusty.", "Błąd wzorca", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
