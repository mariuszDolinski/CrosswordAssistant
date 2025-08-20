using CrosswordAssistant.AppSettings;
using CrosswordAssistant.Entities;

namespace CrosswordAssistant.Searches
{
    public abstract class Search
    {
        protected string AllowedLetters = "aąbcćdeęfghijklłmnńoópqrsśtuvwxyzźż";
        public static SearchMode Mode { get; set; }

        public virtual ValidateResult ValidatePattern(string pattern)
        {
            if (pattern.Length == 0)
            {
                return new ValidateResult(false, "Wzorzec jest pusty.");
            }
            string allowedChars = AllowedLetters;
            if (BaseSettings.CaseSensitive) allowedChars += AllowedLetters.ToUpper();
            foreach (var ch in pattern)
            {
                if (!allowedChars.Contains(ch))
                {
                    return new ValidateResult(false, "Wzorzec zawiera niedozwolone znaki.");
                }
            }
            return new ValidateResult(true, "");
        }
        public abstract List<string> SearchMatches(string pattern);

        protected static bool CheckForAnagram(string pattern, string word)
        {
            if (!BaseSettings.CaseSensitive)
            {
                word = word.ToLower();
            }
            int dots = pattern.CountChars('.');
            int notMatched = 0;
            for (int i = 0; i < word.Length; i++)
            {
                int j = pattern.IndexOf(word[i]);
                if (j == -1)
                {
                    notMatched++;
                    if (notMatched > dots)
                        return false;
                }
                else pattern = pattern.ReplaceAtIndex(j, '+');
            }
            return true;
        }
    }
}
