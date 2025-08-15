using CrosswordAssistant.AppSettings;
using CrosswordAssistant.Entities;

namespace CrosswordAssistant.Searches
{
    public abstract class Search
    {
        protected string AllowedLetters = "aąbcćdeęfghijklłmnńoópqrsśtuvwxyzźż";
        protected bool CaseSensitive = (byte)Settings.SavedSettings[Settings.CaseSensitiveKey] == 1;
        public static SearchMode Mode { get; set; }

        public virtual bool ValidatePattern(string pattern)
        {
            if (pattern.Length == 0)
            {
                MessageBox.Show("Wzorzec jest pusty.", "Błąd wzorca", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            string allowedChars = AllowedLetters;
            if (BaseSettings.CaseSensitive) allowedChars += AllowedLetters.ToUpper();
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
