
using CrosswordAssistant.Services;

namespace CrosswordAssistant.Searches
{
    public class UlozSamSearch : Search
    {
        public override List<string> SearchMatches(string pattern)
        {
            List<string> result = [];
            var strings = pattern.Split('+');
            var digits = GetPatternDigits(strings[0]);
            if (digits.Count == 0) return result;
            var groups = ValidateGroups(strings);
            if (groups.Length == 1) return result;
            int patternLength = digits.Count;
            foreach (var word in DictionaryService.CurrentDictionary)
            {
                string wordL = word.ToLower();
                bool isMatch = true;
                if (word.Length != patternLength) continue;
                for (int i = 0; i < digits.Count; i++)
                {
                    if (!groups[digits[i] - 1].Contains(wordL[i]))
                    {
                        isMatch = false;
                        break;
                    }
                }
                if (isMatch)
                {
                    result.Add(word);
                }
            }

            return result;
        }

        public override ValidateResult ValidatePattern(string pattern)
        {
            if (pattern.Length == 0)
            {
                return new ValidateResult(false, "Wzorzec jest pusty");
            }
            if (GetPatternDigits(pattern).Count == 0)
            {
                return new ValidateResult(false, "Wzorzec zawiera niedozwolone znaki, powinien zawierać tylko cyfry 1-8.");
            }
            return new ValidateResult(true, "");
        }

        private List<int> GetPatternDigits(string pattern)
        {
            List<int> result = [];
            if (pattern.Length == 0) return result;
            if (pattern.Contains('0') || pattern.Contains('9')) return result;
            foreach (var ch in pattern)
            {
                if (int.TryParse(ch.ToString(), out int digit))
                {
                    result.Add(digit);
                }
                else
                {
                    return [];
                }
            }
            return result;
        }
        private string[] ValidateGroups(string[] strings)
        {
            string[] result = new string[8];
            if (strings.Length != 9)
            {
                MessageBox.Show("Błednie zdefiniowane grupy liter.",
                    "Błąd grup", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return ["-1"];
            }
            for (int i = 1; i < strings.Length; i++) 
            {
                result[i - 1] = strings[i];
            }
            if (!CheckGroups(result))
            {
                MessageBox.Show("Grupy zawierają niedozwolone znaki, powinnny zawierać tylko litery polskiego alfabetu.",
                    "Błąd grup", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return ["-1"];
            }
            return result;
        }
        private bool CheckGroups(string[] groups)
        {
            for(int i = 0; i < groups.Length; i++)
            {
                if (!DictionaryService.ValidateAllowedChars(groups[i].ToLower(), DictionaryService.AllowedLetters))
                    return false;
            }
            return true;
        }
    }
}
