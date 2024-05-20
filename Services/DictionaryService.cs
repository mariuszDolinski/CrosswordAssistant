﻿using CrosswordAssistant.Entities;

namespace CrosswordAssistant.Services
{
    public class DictionaryService
    {
        public List<string> CurrentDictionary { get; private set; } = [];
        public SearchMode Mode { get; set; }

        public const string AllowedPatternChars = "aąbcćdeęfghijklłmnńoópqrsśtuvwxyzźż.";
        public const string AllowedLetters = "aąbcćdeęfghijklłmnńoópqrsśtuvwxyzźżAĄBCĆDEĘFGHIJKLŁMNŃOÓPQRSŚTUVWXYZŹŻ";
        public const string AllowedWordChars = "aąbcćdeęfghijklłmnńoópqrsśtuvwxyzźż-AĄBCĆDEĘFGHIJKLŁMNŃOÓPQRSŚTUVWXYZŹŻ";

        public DictionaryService() 
        {
            LoadDictionary();
            Mode = SearchMode.Pattern;
        }

        public void LoadDictionary()
        {
            CurrentDictionary = FileService.ReadDictionary();
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
            if(pattern.Trim() == string.Empty)
                return CurrentDictionary;
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
            if (pattern.Trim() == string.Empty)
                return CurrentDictionary;
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
        /// Return list of words from CurrentDictionary which are metagrams of given pattern
        /// </summary>
        /// <param name="pattern"></param>
        /// <returns></returns>
        public List<string> SearchForMetagrams(string pattern)
        {
            if (pattern.Trim() == string.Empty)
                return CurrentDictionary;
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
        public List<string> SearchPlusMinus1Words(string pattern)
        {
            if (pattern.Trim() == string.Empty)
                return CurrentDictionary;
            List<string> result = [];
            foreach( var word in CurrentDictionary)
            {
                if (pattern.DiffMinusOne(word) || word.DiffMinusOne(pattern))
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
