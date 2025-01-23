namespace CrosswordAssistant.Services
{
    public static class ScrabbleCalculator
    {
        public static int TripleWordBonus { get; set; }
        public static int DoubleWordBonus { get; set; }
        public static int TripleLetterBonus { get; set; }
        public static int DoubleLetterBonus { get; set; }

        public static bool ValidateScrabbleWord(string word)
        {
            if(word.Length < 1 || word.Length > 15)
            {
                MessageBox.Show("Podane słowo musi mieć od 1 do 15 liter.", "Niepoprawne słowo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (!word.OnlyLetters())
            {
                MessageBox.Show("Podane słowo musi składać się jedynie z liter.", "Niepoprawne słowo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            foreach (char c in word) 
            {
                if (word.CountChars(c) > ScrabbleLettersCount(c)) 
                {
                    MessageBox.Show($"Zbyt wiele powtórzeń litery {c.ToString().ToUpper()}.", "Niepoprawne słowo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
            }
            return true;
        }

        public static int CountScrabblePoints(string word, string pattern)
        {
            int result = 0;
            word = word.ToLower();
            if (pattern == "")
            {
                foreach (char c in word)
                {
                    result += ScrabblePointsForLetter(c);
                }
            }
            else
            {
                foreach (char c in word)
                {
                    if (pattern.Contains(c))
                    {
                        result += ScrabblePointsForLetter(c);
                    }
                }
            }
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="c"></param>
        /// <returns>scrabble points for given char (in polish version)</returns>
        private static int ScrabblePointsForLetter(char c)
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
        /// 
        /// </summary>
        /// <param name="c"></param>
        /// <returns>integer indicates the number of specific letter in polish version of Srabble</returns>
        private static int ScrabbleLettersCount(char c)
        {
            return c switch
            {
                'ą' or 'ć' or 'ę' or 'f' or 'ń' or 'ó' or 'ś' or 'ż' or 'ź' => 1,
                'b' or 'g' or 'h' or 'j' or 'ł' or 'u' => 2,
                'c' or 'd' or 'k' or 'l' or 'm' or 'p' or 't' => 3,
                'r' or 's' or 'w' or 'y' => 4,
                'n' or 'z' => 5,
                'o' => 6,
                'e' => 7,
                'i' => 8,
                'a' => 9,
                _ => 0,
            };
        }
    }
}
