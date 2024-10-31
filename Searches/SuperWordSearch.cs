using CrosswordAssistant.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrosswordAssistant.Searches
{
    internal class SuperWordSearch : Search
    {
        public override List<string> SearchMatches(string pattern)
        {
            List<string> result = [];
            foreach (var word in DictionaryService.CurrentDictionary)
            {
                if (word.IsSubword(pattern))
                {
                    result.Add(word);
                }
            }
            return result;
        }
    }
}
