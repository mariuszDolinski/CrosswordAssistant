
using CrosswordAssistant.Services;

namespace CrosswordAssistant.Searches
{
    public class MetagramSearch : Search
    {
        /// <summary>
        /// Search for words which differ with exactly one letter from given pattern.
        /// </summary>
        /// <param name="pattern"></param>
        /// <returns>list of words from CurrentDictionary which are metagrams of given pattern</returns>
        public override List<string> SearchMatches(string pattern)
        {
            List<string> result = [];
            foreach (var word in DictionaryService.CurrentDictionary)
            {
                if (word.IsMetagram(pattern))
                {
                    result.Add(word);
                }
            }
            return result;
        }
    }
}
