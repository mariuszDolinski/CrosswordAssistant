
using CrosswordAssistant.Services;
using System.CodeDom.Compiler;
using System.Text;

namespace CrosswordAssistant.Searches
{
    public class WordInWordSearch : Search
    {
        public override List<string> SearchMatches(string pattern)
        {
            List<string> preResult = [];
            List<string> result = [];

            var patternSearch = new PatternSearch();
            preResult = patternSearch.SearchMatches(pattern);

            //int kropkiCount = pattern.Count(c => c == '.');
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

        //TO DO - nadpisać ValidatePattern, aby spradzał czy wzorzec zawiera minimum 3 kropki
        public override bool ValidatePattern(string pattern)
        {
            if (pattern.Length == 0)
            {
                MessageBox.Show("Wzorzec jest pusty.", "Błąd wzorca", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            string allowedChars = "aąbcćdeęfghijklłmnńoópqrsśtuvwxyzźż.";
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
