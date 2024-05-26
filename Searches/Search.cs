namespace CrosswordAssistant.Searches
{
    public abstract class Search
    {
        public abstract bool ValidatePattern(string pattern);
        public abstract List<string> SearchMatches(string pattern);
    }
}
