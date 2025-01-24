using CrosswordAssistant.Entities;
using System.Linq;

namespace CrosswordAssistant.Services
{
    public static class ScrabbleCalculator
    {
        public static int TripleWordBonus { get; set; }
        public static int DoubleWordBonus { get; set; }
        public static int TripleLetterBonus { get; set; }
        public static int DoubleLetterBonus { get; set; }

        public static bool ValidateScrabbleWord(string word, string blanks)
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

            foreach (char c in blanks)
            {
                if (word.Contains(c))
                {
                    word = word.Remove(word.IndexOf(c), 1);
                }
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
        public static int CountBaseScrabblePoints(string word, string pattern)
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
                var temp = pattern.ToLower();
                foreach (char c in word)
                {
                    if (temp.Contains(c))
                    {
                        result += ScrabblePointsForLetter(c);
                        temp = temp.ReplaceAtIndex(temp.IndexOf(c),'.');
                    }
                }
            }
            return result;
        }
        public static int CalculateScrabbleScoreForWord(ScrabbleCalculatorRequest request)
        {
            if(!ValidateScrabbleBonuses(request))
                return 0;

            var score = CountBaseScrabblePoints(request.Word, "");
            if (request.Blanks.Length > 0) 
            {
                foreach( var b in request.Blanks)
                {
                    score -= ScrabblePointsForLetter(b);
                }
            }
            if (request.DoubleBonusLetters.Length > 0)
            {
                foreach(var c in request.DoubleBonusLetters)
                {
                    score += ScrabblePointsForLetter(c);
                }
            }
            if (request.TripleBonusLetters.Length > 0)
            {
                foreach (var c in request.TripleBonusLetters)
                {
                    score += 2 * ScrabblePointsForLetter(c);
                }
            }
            score *= (int)Math.Pow(2, request.DoubleWordBonus);
            score *= (int)Math.Pow(3, request.TripleWordBonus);

            return score;
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
        private static bool ValidateScrabbleBonuses(ScrabbleCalculatorRequest request)
        {
            //walidacja wyrazu
            if (!ValidateScrabbleWord(request.Word, request.Blanks)) return false;

            //walidacje premi wyrazowych
            if (request.TripleWordBonus > 0 && request.DoubleWordBonus > 0)
            {
                MessageBox.Show("Obie premie wyrazowe nie mogą być aktywne jednocześnie.", "Błąd premii wyrazowej", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (request.TripleWordBonus == 2 && request.Word.Length < 8)
            {
                MessageBox.Show("W podanym wyrazie nie można zastosować dwóch potrójnych premii wyrazowych. Wyraz jest za krótki.", 
                    "Błąd premii wyrazowej", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            } 
            if (request.TripleWordBonus == 3 && request.Word.Length < 15)
            {
                MessageBox.Show("W podanym wyrazie nie można zastosować trzech potrójnych premii wyrazowych. Wyraz jest za krótki.",
                    "Błąd premii wyrazowej", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (request.DoubleWordBonus == 2 && request.Word.Length < 7)
            {
                MessageBox.Show("W podanym wyrazie nie można zastosować dwóch podwójnych premii wyrazowych. Wyraz jest za krótki.",
                    "Błąd premii wyrazowej", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            //walidacje premii literowych
            if (request.DoubleBonusLetters.Length > 0 && request.TripleBonusLetters.Length > 0) 
            {
                MessageBox.Show("Obie premie literowe nie mogą być aktywne jednocześnie.", "Błąd premii literowej", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if((request.DoubleBonusLetters.Length > 0 && !request.DoubleBonusLetters.OnlyLetters())
                || (request.TripleBonusLetters.Length > 0 && !request.TripleBonusLetters.OnlyLetters()))
            {
                MessageBox.Show("W premii literowej znajdują się znaki inne niż litery.", "Błąd premii literowej", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (!request.Word.ContainsAllLetters(request.DoubleBonusLetters) || !request.Word.ContainsAllLetters(request.TripleBonusLetters))
            {
                MessageBox.Show("W premii literowej znajdują się znaki, których nie ma w podanym wyrazie.", "Błąd premii literowej", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            //walidacje blank
            foreach (var c in request.Blanks)
            {
                if (!Char.IsLetter(c))
                {
                    MessageBox.Show("Blank powinien być literą.", "Błąd blanka", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
                if (!request.Word.Contains(c))
                {
                    MessageBox.Show("Litera podana jako blank, nie występuje w podanym wyrazie.", "Błąd blanka", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
            }
            if(request.Blanks.Length == 2)
            {
                if (request.Blanks[0] == request.Blanks[1] 
                    && request.Word.CountChars(request.Blanks[0]) < 2)
                {
                    MessageBox.Show("Nie wszystkie blanki występują w wyrazie.", "Błąd blanka", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
            }
            return true;
        }
    }
}
