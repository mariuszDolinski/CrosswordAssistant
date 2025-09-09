using CrosswordAssistant.Entities.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrosswordAssistant.Searches
{
    internal class CryptharitmSearch : Search
    {
        public override List<string> SearchMatches(string pattern)
        {
            List<string> result = [];
            var letters = GetAllDistinctLetters(pattern);
            var words = pattern.Split('|');

            GenerateCase([.. Enumerable.Range(0, 10)], letters.Count, currentCase =>
            {
                var map = new Dictionary<char, int>();
                for (int i = 0; i < letters.Count; i++)
                {
                    map[letters[i]] = currentCase[i];
                }

                if (words.Any(w => map[w[0]] == 0)) return;

                long[] numbers = new long[words.Length];
                long sum = 0;
                for(int i = 0; i < words.Length; i++)
                {
                    numbers[i] = GetNumberFromWord(words[i], map);
                    if(i < words.Length - 1) sum += numbers[i];
                }

                if(sum == numbers[^1])
                {
                    result.Add(BuildSolution(letters, map, numbers));
                }
            });

            return result;
        }

        public override ValidationResponse ValidatePattern(string pattern)
        {
            var words = pattern.Split('|');
            foreach (var word in words)
            {
                if(word.Length == 0)
                {
                    return new ValidationResponse(false, "Podaj wszystkie dane. Któreś z pól tekstowych jest puste.");
                }
                else
                {
                    if (word.Length > 10)
                        return new ValidationResponse(false, "Któreś z pól zawiera zbyt dużo znaków. Obsługiwane są liczby złożone z maksymalnie 10 cyfr.");
                    foreach (var c in word.ToLower())
                    {
                        if (!AllowedLetters.Contains(c))
                        {
                            return new ValidationResponse(false, "Wykryto niedozwolony znak. Używaj tylko liter polskiego alabetu.");
                        }
                    }
                }
            }
            if (GetAllDistinctLetters(pattern).Count > 10)
                return new ValidationResponse(false, "Za dużo różnych liter. Można użyć maksymalnie 10.");

            return new ValidationResponse(true, "");
        }

        private static List<char> GetAllDistinctLetters(string pattern) 
            => new HashSet<char>(pattern.Replace("|","")).ToList();

        private static string BuildSolution(List<char> letters, Dictionary<char,int> map, long[] numbers)
        {
            var solution = string.Empty;
            for (int i = 0; i < letters.Count; i++)
            {
                solution += letters[i] + " = " + map[letters[i]];
                if (i < letters.Count - 1) solution += ", ";
            }
            solution += "|";
            for(int i = 0; i < numbers.Length - 1; i++)
            {
                solution += numbers[i].ToString();
                if(i <  numbers.Length - 2) solution += " + ";
            }
            solution += " = " + numbers[^1].ToString();
            return solution;
        }
        private static long GetNumberFromWord(string word, Dictionary<char, int> map)
        {
            long result = 0;
            foreach(var c in word)
                result = 10 * result + map[c];
            return result;
        }
        private static void GenerateCase(List<int> digits, int lettersCount, Action<List<int>> checkCase)
        {
            GenerateNextCase([], digits, lettersCount, checkCase);
        }
        private static void GenerateNextCase(List<int> currentCase, List<int> remainDigits, int lettersCount, Action<List<int>> checkCase)
        {
            if(currentCase.Count == lettersCount)
            {
                checkCase(currentCase);
                return;
            }
            for(int i = 0; i < remainDigits.Count; i++)
            {
                var newCase = new List<int>(currentCase) { remainDigits[i] };
                var newRemainDigits = new List<int>(remainDigits);
                newRemainDigits.RemoveAt(i);
                GenerateNextCase(newCase, newRemainDigits, lettersCount, checkCase);
            }
        }
    }
}
