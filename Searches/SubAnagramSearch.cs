
using CrosswordAssistant.AppSettings;
using CrosswordAssistant.Entities.Responses;

namespace CrosswordAssistant.Searches
{
    public class SubAnagramSearch : Search
    {
        public override List<string> SearchMatches(string pattern)
        {
            List<string> results = [];
            
            var patternParts = pattern.Split('|');
            PatternSearch patternSearch = new PatternSearch();
            var newPattern = string.Empty;
            List<int> anagramLettersPositions = [];
            int n = 0;
            foreach (var ch in patternParts[0])
            {
                if(ch == '*')
                {
                    newPattern += "[" + patternParts[1] + "]";
                    anagramLettersPositions.Add(n);
                }
                else
                {
                    newPattern += ch;
                }
                n++;
            }
            results = patternSearch.SearchMatches(newPattern);
            List<string> finalResults = [];
            foreach (var word in results)
            {
                var anagramLetters = patternParts[1];
                var isCorrectResult = true;
                for(int i = 0; i < word.Length; i++) 
                {
                    if (anagramLettersPositions.Contains(i))
                    {
                        if (!anagramLetters.Contains(word[i]))
                        {
                            isCorrectResult = false;
                            break;
                        }
                        else
                        {
                            anagramLetters = anagramLetters.ReplaceAtIndex(anagramLetters.IndexOf(word[i]), '-');
                        }
                    }
                }
                if (isCorrectResult) finalResults.Add(word);
            }
            return finalResults;
        }

        public override ValidationResponse ValidatePattern(string pattern)
        {
            if (pattern.Length == 0)
            {
                return new ValidationResponse(false, "Wzorzec jest pusty.");
            }
            if (pattern.CountChars('|') != 1)
            {
                return new ValidationResponse(false, "Wzorzec powinien zawierać dokładnie jeden znak |");
            }
            if (!pattern.Contains('*'))
            {
                return new ValidationResponse(false, "Wzorzec na lewo od znaku | powinien zawierać co najmniej jeden znak *");
            }
            var patternParts = pattern.Split('|');
            string allowedLetters = AllowedLetters;
            if (BaseSettings.CaseSensitive) allowedLetters += AllowedLetters.ToUpper();
            string allowedChars = allowedLetters + ".?*|";
            foreach (var ch in patternParts[0])
            {
                if (!allowedChars.Contains(ch))
                {
                    return new ValidationResponse(false, "Wzorzec zawiera niedozwolone znaki");
                }
            }
            foreach(var ch in patternParts[1])
            {
                if (!allowedLetters.Contains(ch))
                {
                    return new ValidationResponse(false, "Wzorzec po znaku | powinien zawierać tylko litery");
                }
            }
            if (patternParts[0].CountChars('*') != patternParts[1].Length)
            {
                return new ValidationResponse(false, "Ilość znaków * powinna być równa ilości liter po znaku |");
            }

            return new ValidationResponse(true, "");
        }
    }
}
