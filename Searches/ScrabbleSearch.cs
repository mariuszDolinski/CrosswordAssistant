using CrosswordAssistant.Services;

namespace CrosswordAssistant.Searches
{
    public class ScrabbleSearch : Search
    {
        public override List<string> SearchMatches(string pattern)
        {
            List<string> result = [];
            foreach (var word in DictionaryService.CurrentDictionary)
            {
                if (word.Length > pattern.Length) continue;
                if (word.Length < 4 || word.Length > 14) continue;
                if (CheckForAnagram(pattern.ToLower(), word.ToLower()))
                {
                    result.Add($"{word}({CountScrabblePoints(word,pattern)})");
                }
            }
            return result;
        }
        public override bool ValidatePattern(string pattern)
        {
            if (pattern.Length < 4 || pattern.Length > 15 || pattern.CountChars('.') > 2)
            {
                MessageBox.Show("Wzorzec powinien zawierać od 4 do 15 znaków, w tym co najwyżej dwa mydła",
                    "Błędny wzorzec", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (!DictionaryService.ValidateAllowedChars(pattern, DictionaryService.AllowedPatternChars))
            {
                MessageBox.Show("Wzorzec zawiera niedozwolone znaki", "Błędny wzorzec",
                     MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="c"></param>
        /// <returns>scrabble points for given char</returns>
        private static int ScrabblePointsForChar(char c)
        {
            return c switch
            {
                'a' or 'e' or 'i' or 'o' or 'n' or 'z' or 'r' or 's' or 'w' => 1,
                'y' or 'c' or 'd' or 'k' or 'l' or 'm' or 'p' or 't' => 2,
                'b' or 'g' or 'h' or 'j' or 'ł' or 'u' => 3,
                'ą' or 'ę' or 'f' or 'ó' or 'ś' or 'ż' => 5,
                'ć' => 6,
                'ń' => 7,
                'ź' => 9,
                _ => 0,
            };
        }
        /// <summary>
        /// Calculate scrabble points for given word. If pattern is given only letters which appears
        /// in pattern are counting in scrabble score.
        /// </summary>
        /// <param name="word"></param>
        /// <param name="pattern"></param>
        /// <returns>scrabble points for given word</returns>
        private static int CountScrabblePoints(string word, string pattern)
        {
            int result = 0;
            word = word.ToLower();
            if (pattern == "")
            {
                foreach (char c in word)
                {
                    result += ScrabblePointsForChar(c);
                }
            }
            else
            {
                foreach (char c in word)
                {
                    if (pattern.Contains(c))
                    {
                        result += ScrabblePointsForChar(c);
                    }
                }
            }
            return result;
        }
    }
}
