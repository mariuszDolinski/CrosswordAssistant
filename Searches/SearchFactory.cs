using CrosswordAssistant.Entities;
using CrosswordAssistant.Services;

namespace CrosswordAssistant.Searches
{
    public class SearchFactory()
    {
        public Search CreateSearch(SearchMode mode)
        {
            switch(mode)
            {
                case SearchMode.Pattern: return new PatternSearch();
                case SearchMode.Anagram: return new AnagramSearch();
                case SearchMode.Metagram: return new MetagramSearch();
                case SearchMode.PlusMinus1: return new PlusMinus1Search();
                case SearchMode.UluzSam: return new UlozSamSearch();
                case SearchMode.Scrabble: return new ScrabbleSearch();
                case SearchMode.SubWord: return new SubWordSearch();
                default: throw new NotImplementedException("SearchFactory Error: Search not implememnted");
            }
        }
    }
}
