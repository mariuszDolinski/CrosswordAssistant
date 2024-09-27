using CrosswordAssistant.Services;

namespace CrosswordAssistant.Searches
{
    internal class SubWordSearch : Search
    {
        public override List<string> SearchMatches(string pattern)
        {
            List<string> result = [];
            foreach (var word in DictionaryService.CurrentDictionary)
            {
                if(word.Length < 3) continue;
                if (pattern.IsSubword(word))
                {
                    result.Add(word);
                }
            }
            return result;
        }
    }
}
