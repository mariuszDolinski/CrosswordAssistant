using CrosswordAssistant.Entities;
using CrosswordAssistant.Searches;

namespace CrosswordAssistant.Services
{
    public class DictionaryService
    {
        public static List<string> CurrentDictionary { get; private set; } = [];
        public static bool PendingDictionaryLoading { get; set; } = false;

        public const string AllowedPatternChars = "aąbcćdeęfghijklłmnńoópqrsśtuvwxyzźż.";
        public const string AllowedLetters = "aąbcćdeęfghijklłmnńoópqrsśtuvwxyzźżAĄBCĆDEĘFGHIJKLŁMNŃOÓPQRSŚTUVWXYZŹŻ";
        public const string AllowedWordChars = "aąbcćdeęfghijklłmnńoópqrsśtuvwxyzźż-AĄBCĆDEĘFGHIJKLŁMNŃOÓPQRSŚTUVWXYZŹŻ";

        public DictionaryService() 
        {
            LoadDictionary();
            Search.Mode = SearchMode.Pattern;
        }

        public void LoadDictionary()
        {
            CurrentDictionary.TrimExcess();//memory optimalization
            CurrentDictionary = FileService.ReadDictionary();
        }
        public async Task LoadDictionaryAsync()
        {
            CurrentDictionary.TrimExcess();//memory optimalization
            CurrentDictionary = await FileService.ReadDictionaryAsync();
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
        /// Add given list of words to CurrentDictionary. Preserve alphabetical order.
        /// Return list of added words. If empty list is returned, no words was added.
        /// </summary>
        /// <param name="words"></param>
        /// <returns></returns>
        public List<string> AddWordsToDictionary(List<string> words)
        {
            List<string> wordsAdded = [];
            var tmpDictionary = new List<string>(CurrentDictionary);
            bool isLast; //if true, newWord has to be add at the end of Dictionary
            foreach(var newWord in words) 
            {
                isLast = true;
                foreach(var word in CurrentDictionary)
                {
                    if (newWord.ToLower() == word.ToLower())
                    {
                        isLast = false;
                        break;
                    }
                    if (string.Compare(newWord, word, StringComparison.CurrentCulture) > 0) 
                        continue;
                    tmpDictionary.Insert(tmpDictionary.IndexOf(word), newWord);
                    wordsAdded.Add(newWord);
                    isLast = false;
                    break;
                }
                if (isLast)
                {
                    tmpDictionary.Add(newWord);
                    wordsAdded.Add(newWord);
                }
                CurrentDictionary = tmpDictionary;
            }
            return wordsAdded;
        }

        public static List<string> RemoveWordsFromDictionary(List<string> words)
        {
            var removedWords = new List<string>();
            foreach(var word in words)
            {
                if(CurrentDictionary.Contains(word))
                {
                    removedWords.Add(word);
                    CurrentDictionary.Remove(word);
                }
            }
            return removedWords;
        }
        
        /// <summary>
        /// Return: true if pattern contains only allowed chars, specified in allowedChars string
        /// </summary>
        /// <param name="pattern"></param>
        /// <returns></returns>
        public static bool ValidateAllowedChars(string pattern, string allowedChars)
        {
            foreach (var ch in pattern)
            {
                if (!allowedChars.Contains(ch))
                    return false;
            }
            return true;
        }

        public static bool ValidateWordsToAdd(List<string> words)
        {
            foreach(var word in words)
            {
                if(word.Length == 0) continue;
                if(!AllowedLetters.Contains(word[0]) || !AllowedLetters.Contains(word[^1]))
                {
                    return false;
                }
                if(!ValidateAllowedChars(word, AllowedWordChars))
                {
                    return false;
                }
            }
            return true;
        }
        
        public int GetWordsCount()
            => CurrentDictionary.Count;
    }
}
