﻿using CrosswordAssistant.Services;

namespace CrosswordAssistant.Searches
{
    public class PatternSearch : Search
    {
        /// <summary>
        /// Search words which match given pattern.
        /// Dot (.) replace any letter.
        /// </summary>
        /// <param name="pattern"></param>
        /// <returns>list of words from CurrentDictionary which match given pattern. </returns>
        public override List<string> SearchMatches(string pattern)
        {
            List<string> result = [];
            bool isMatch;

            foreach (var word in DictionaryService.CurrentDictionary)
            {
                if (word is null) continue;
                if (word.Length != pattern.Length) continue;
                isMatch = true;
                for (int i = 0; i < word.Length; i++)
                {
                    if (pattern[i] == '.') continue;
                    else if (pattern[i] != word.ToLower()[i])
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
