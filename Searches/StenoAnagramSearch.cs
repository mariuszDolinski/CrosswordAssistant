
using CrosswordAssistant.Services;

namespace CrosswordAssistant.Searches
{
    public class StenoAnagramSearch : Search
    {
        public override List<string> SearchMatches(string pattern)
        {
            List<string> result = [];
            bool isCorrect;
            foreach (var word in DictionaryService.CurrentDictionary)
            {
                if (word == pattern) continue;
                isCorrect = true;
                var tmp = pattern;
                foreach (char c in word) 
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
            return result;
        }

        public override bool ValidatePattern(string pattern)
        {
            if (base.ValidatePattern(pattern))
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
    }
}
