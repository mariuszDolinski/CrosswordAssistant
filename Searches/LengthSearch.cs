
using CrosswordAssistant.Services;

namespace CrosswordAssistant.Searches
{
    public class LengthSearch : Search
    {
        /// <summary>
        /// Search for words with length in given range inclusive.
        /// </summary>
        /// <param name="pattern">string with format 'min-max'</param>
        /// <returns>list of words in CurrentDictionary with length in given range.</returns>
        public override List<string> SearchMatches(string pattern)
        {
            List<string> result = [];
            var boundries = GetBoundries(pattern);
            if (boundries[0] == -1) return result;

            foreach (var word in DictionaryService.CurrentDictionary)
            {
                if (word.Length >= boundries[0] && word.Length <= boundries[1])
                {
                    result.Add(word);
                }
            }

            return result;
        }

        public override bool ValidatePattern(string pattern)
        {
            var validate = GetBoundries(pattern);
            if (validate[0] == -1)
            {
                MessageBox.Show("Błędny zakres długości. Podaj poprawne liczby.", "Błąd długości", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        private int[] GetBoundries(string pattern)
        {
            int[] boundries = new int[2];
            var bounds = pattern.Split('+');
            if (bounds.Length != 2 )
            {
                return [-1];
            }
            if (int.TryParse(bounds[0], out var min))
            {
                boundries[0] = min;
            }
            else
            {
                return [-1];
            }
            if (int.TryParse(bounds[1], out var max))
            {
                boundries[1] = max;
            }
            else
            {
                return [-1];
            }
            if (boundries[0] <= 0 || boundries[1] <= 0 || boundries[0] > boundries[1])
            {
                return [-1];
            }

            return boundries;
        }
    }
}
