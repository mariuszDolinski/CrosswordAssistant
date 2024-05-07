using CrosswordAssistant.Entities;

namespace CrosswordAssistant.Services
{
    public class DictionaryService
    {
        public List<string> CurrentDictionary { get; set; }
        public SearchMode Mode { get; set; }

        public const string AllowedChars = "aąbcćdeęfghijklłmnńoópqrsśtuvwxyzźż.";
        public const string AllowedLetters = "aąbcćdeęfghijklłmnńoópqrsśtuvwxyzźż";

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
                if(word.Equals(pattern, StringComparison.CurrentCultureIgnoreCase)) continue;
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
                }
            }

            return result;
        }
        /// <summary>
        /// Return: list of words in CurrentDictionary with length is in given range.
        /// </summary>
        /// <param name="min">range lower boundry</param>
        /// <param name="max">range upper boundry</param>
        /// <returns></returns>
        public List<string> SearchWithGivenLength(int min, int max)
        {
            List<string> result = [];
            foreach(var word in CurrentDictionary)
            {
                if (word.Length >= min && word.Length <= max)
                {
                    result.Add(word);
                }
            }

            return result;  
        }
        /// <summary>
        /// Return list of words from CurrentDictionary which are metagrams of given pattern
        /// </summary>
        /// <param name="pattern"></param>
        /// <returns></returns>
        public List<string> SearchForMetagrams(string pattern)
        {
            List<string> result = [];
            foreach (var word in CurrentDictionary)
            {
                if (word.IsMetagram(pattern))
                {
                    result.Add(word);
                }
            }
            return result;
        }
        public List<string> SearchUluzSam(List<int> digits, string[] groups)
        {
            List<string> result = [];
            int patternLength = digits.Count;
            foreach(var word in CurrentDictionary)
            {
                string wordL = word.ToLower();
                bool isMatch = true;
                if (word.Length != patternLength) continue;
                for(int i=0; i<digits.Count; i++)
                {
                    if (!groups[digits[i] - 1].Contains(wordL[i]))
                    {
                        isMatch = false;
                        break;
                    }
                }
                if (isMatch)
                {
                    result.Add(word);
                }                   
            }

            return result;
        }
        /// <summary>
        /// Return: true if pattern contains only allowed chars, specified in allowedChars string
        /// </summary>
        /// <param name="pattern"></param>
        /// <returns></returns>
        public static bool ValidatePattern(string pattern, string allowedChars)
        {
            foreach (var ch in pattern)
            {
                if (!allowedChars.Contains(ch))
                    return false;
            }
            return true;
        }
        public string RenderLoadInfo()
        {
            return "Słownik " + FileService.FileName + " został wczytany poprawnie."
                + Environment.NewLine + "Słownik zawiera " + CurrentDictionary.Count + " wyrazów.";
        }

    }
}
