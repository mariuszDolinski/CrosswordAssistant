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
        /// Return true if dictionary was not loaded properly. Return false otherwise.
        /// </summary>
        /// <returns></returns>
        public bool DictionaryLoadError()
        {
            return CurrentDictionary.Count == 1 && CurrentDictionary[0] == Messages.NoFile;
        }
        /// <summary>
        /// Return list of words from CurrentDictionary which match given pattern. 
        /// Dot (.) replace any letter.
        /// </summary>
        /// <param name="pattern"></param>
        /// <returns></returns>
        public List<string> SearchByPattern(string pattern) 
        {
            List<string> result = [];
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
        /// <summary>
        /// Return list of words from CurrentDictionary which contains excatly the same letters
        /// as in pattern. Dot (.) replace any letter.
        /// </summary>
        /// <param name="pattern"></param>
        /// <returns></returns>
        public List<string> SearchForAnagrams(string pattern)
        {
            List<string> result = [];
            bool isAnagram;

            foreach(var word in CurrentDictionary)
            {
                isAnagram = true;
                if(word is null) continue;
                if(word.Length != pattern.Length) continue;
                if(word == pattern) continue;
                string tmp = word.ToLower();
                for(int i=0; i<pattern.Length; i++)
                {
                    if (pattern[i] == '.') continue;
                    int j = tmp.IndexOf(pattern[i]);
                    if (j == -1) 
                    {
                        isAnagram = false; 
                        break;
                    } 
                    else tmp = tmp.ReplaceAtIndex(j, '+');
                }
                if (!isAnagram) continue;
                if(pattern.CountChars('.',0) == tmp.CountChars('+', 1))
                {
                    result.Add(word);
                    if(result.Count == 500) break;
                }
            }

            return result;
        }

    }
}
