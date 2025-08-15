using CrosswordAssistant.AppSettings;
using CrosswordAssistant.Services;

namespace CrosswordAssistant.Searches
{
    internal class SubWordSearch : Search
    {
        public override List<string> SearchMatches(string pattern)
        {
            List<string> result = [];
            if (!BaseSettings.CaseSensitive)
            {
                foreach (var word in DictionaryService.CurrentDictionary)
                {
                    if (pattern.IsSubword(word.ToLower()))
                    {
                        result.Add(word);
                    }
                }
            }
            else
            {
                foreach (var word in DictionaryService.CurrentDictionary)
                {
                    if (pattern.IsSubword(word))
                    {
                        result.Add(word);
                    }
                }
            }
            return result;
        }
    }
}
