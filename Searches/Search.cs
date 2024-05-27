using CrosswordAssistant.Entities;

namespace CrosswordAssistant.Searches
{
    public abstract class Search
    {
        public static SearchMode Mode { get; set; }
        public abstract bool ValidatePattern(string pattern);
        public abstract List<string> SearchMatches(string pattern);

        protected static bool CheckForAnagram(string pattern, string word)
        {
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
