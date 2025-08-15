
using CrosswordAssistant.AppSettings;
using CrosswordAssistant.Services;
using System.Collections.Generic;

namespace CrosswordAssistant.Searches
{
    public class StenoAnagramSearch : Search
    {
        public override List<string> SearchMatches(string pattern)
        {
            List<string> result = [];
            if(BaseSettings.CaseSensitive)
            {
                foreach (var word in DictionaryService.CurrentDictionary)
                {
                    StenoAnagramCheck(pattern, word, word, result);
                }
            }
            else
            {
                pattern = pattern.ToLower();
                foreach (var word in DictionaryService.CurrentDictionary)
                {
                    StenoAnagramCheck(pattern, word, word.ToLower(), result);
                }
            }
            
            return result;
        }

        public override bool ValidatePattern(string pattern)
        {
            if (!base.ValidatePattern(pattern))
            {
                return false;
            }
            else
            {
                foreach (char c in pattern)
                {
                    if (pattern.CountChars(c) > 1)
                    {
                        MessageBox.Show("Wzorzec zawiera powtórzone litery.", "Błąd wzorca", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false;
                    }
                }
            }
            return true;
        }

        private static void StenoAnagramCheck(string pattern, string word, string csWord, List<string> result)
        {
            if (csWord == pattern) return;
            bool isCorrect = true;
            var tmp = pattern;
            foreach (char c in csWord)
            {
                if (!pattern.Contains(c))
                {
                    isCorrect = false;
                    break;
                }
                else
                {
                    tmp = tmp.Replace(c, ' ');
                }
            }
            if (isCorrect && tmp.Trim().Length == 0) result.Add(word);
        }
    }
}
