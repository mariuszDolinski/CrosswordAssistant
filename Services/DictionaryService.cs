using CrosswordAssistant.Entities;

namespace CrosswordAssistant.Services
{
    public class DictionaryService
    {
        public List<string> CurrentDictionary { get; set; }
        public SearchMode Mode { get; set; }

        public DictionaryService() 
        {
            CurrentDictionary = FileService.ReadDictionary();
            Mode = SearchMode.Pattern;
        }

        /// <summary>
        /// Return true if dictionary was not loaded properly. return false otherwise
        /// </summary>
        /// <returns></returns>
        public bool DictionaryLoadError()
        {
            return CurrentDictionary.Count == 1 && CurrentDictionary[0] == Messages.NoFile;
        }
        public List<string> SearchByPattern(string pattern) 
        {
            List<string> result = new List<string>();
            bool isMatch;

            foreach(var word in CurrentDictionary)
            {
                if(word is null) continue;
                if(word.Length != pattern.Length) continue;
                isMatch = true;
                for(int i = 0; i < word.Length; i++)
                {
                    if (pattern[i] == '.') continue;
                    else if (pattern[i] != word.ToLower()[i])
                    {
                        isMatch = false;
                        break;
                    }
                }
                if (isMatch)
                {
                    result.Add(word);
                    if (result.Count == 500) break;
                }
            }
            return result;
        }

    }
}
