using CrosswordAssistant.Entities.Enums;
using CrosswordAssistant.Services;

namespace CrosswordAssistant.Searches
{
    public class SearchFactory()
    {
        public static Search CreateSearch(SearchMode mode)
        {
            return mode switch
            {
                SearchMode.Pattern => new PatternSearch(),
                SearchMode.Anagram => new AnagramSearch(),
                SearchMode.Metagram => new MetagramSearch(),
                SearchMode.PlusMinus1 => new PlusMinus1Search(),
                SearchMode.UluzSam => new UlozSamSearch(),
                SearchMode.Scrabble => new ScrabbleSearch(),
                SearchMode.SubWord => new SubWordSearch(),
                SearchMode.SuperWord => new SuperWordSearch(),
                SearchMode.StenoAnagram => new StenoAnagramSearch(),
                SearchMode.WordInWord => new WordInWordSearch(),
                SearchMode.Cryptharitm => new CryptharitmSearch(),
                _ => throw new NotImplementedException("SearchFactory Error: Search not implemented"),
            };
        }
    }
}
