
using CrosswordAssistant.Services;

namespace CrosswordAssistant.Searches
{
    public class PlusMinus1Search : Search
    {
        public override List<string> SearchMatches(string pattern)
        {
            List<string> result = [];

            foreach (var word in DictionaryService.CurrentDictionary)
            {
                if (pattern.DiffMinusOne(word) || word.DiffMinusOne(pattern))
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
            string allowedChars = "aąbcćdeęfghijklłmnńoópqrsśtuvwxyzźż";
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
