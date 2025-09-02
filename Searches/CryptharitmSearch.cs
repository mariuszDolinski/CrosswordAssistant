using CrosswordAssistant.Entities.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrosswordAssistant.Searches
{
    internal class CryptharitmSearch : Search
    {
        public override List<string> SearchMatches(string pattern)
        {
            throw new NotImplementedException();
        }

        public override ValidationResponse ValidatePattern(string pattern)
        {
            var words = pattern.Split('|');
            var letters = string.Empty;
            foreach (var word in words)
            {
                if(word.Length == 0)
                {
                    return new ValidationResponse(false, "Podaj wszystkie dane. Któreś z pól tekstowych jest puste.");
                }
                else
                {
                    if (word.Length > 10)
                        return new ValidationResponse(false, "Któreś z pól zawiera zbyt dużo znaków. Obsługiwane są liczby złożone z maksymalnie 10 cyfr.");
                    foreach (var c in word.ToLower())
                    {
                        if (!AllowedLetters.Contains(c))
                        {
                            return new ValidationResponse(false, "Wykryto niedozwolony znak. Używaj tylko liter polskiego alabetu.");
                        }
                        else
                        {
                            if (!letters.Contains(c))
                            {
                                letters += c;
                            }
                        }
                    }
                }
            }
            if (letters.Length > 10)
                return new ValidationResponse(false, "Za dużo różnych liter. Można użyć maksymalnie 10.");

            return new ValidationResponse(true, "");
        }
    }
}
