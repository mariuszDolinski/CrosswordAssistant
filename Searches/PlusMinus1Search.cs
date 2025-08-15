
using CrosswordAssistant.AppSettings;
using CrosswordAssistant.Services;

namespace CrosswordAssistant.Searches
{
    public class PlusMinus1Search : Search
    {
        public override List<string> SearchMatches(string pattern)
        {
            List<string> result = [];

            if (!BaseSettings.CaseSensitive)
            {
                foreach (var word in DictionaryService.CurrentDictionary)
                {
                    if (pattern.DiffMinusOne(word.ToLower()) || word.ToLower().DiffMinusOne(pattern))
                    {
                        result.Add(word);
                    }
                }
            }
            else
            {
                foreach (var word in DictionaryService.CurrentDictionary)
                {
                    if (pattern.DiffMinusOne(word) || word.DiffMinusOne(pattern))
                    {
                        result.Add(word);
                    }
                }
            }
            return result;
        }
    }
}
