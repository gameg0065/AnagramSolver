using System.Collections.Generic;
using AnagramSolver.Interfaces;
using System.Linq;
using System;

namespace AnagramSolver.BusinessLogic
{
    public class AnagramGenerator: IAnagramSolver
    {
        public Dictionary<string, string> GenerateAnagrams(string word, int maxNumberOfAnagrams)
        {
            Dictionary<string, string> generatedAnagrams = new Dictionary<string, string>();
            var test = word.ToCharArray();
            var q = word.Select(x => x.ToString());
            for (int i = 0; i < 1; i++) {
                List<string> mytest = new List<string>();
                Recursion(test[i], i + 1, test, 0, mytest);
            }
            foreach (var item in q) {
                // Console.WriteLine(item);
                DictionaryManager theDictionaryManager = new DictionaryManager();
                if(theDictionaryManager.CheckIfExists(item) && item != word && !generatedAnagrams.ContainsKey(item) && generatedAnagrams.Count < maxNumberOfAnagrams) {
                    generatedAnagrams.Add(key: item, item);
                }
            }
            return generatedAnagrams;
        }
        public void Recursion(char letter, int number, char[] word, int max, List<string> newWord) {
            max++;
            if(number < 0 || number > word.Length - 1 || max == word.Length) {
                Console.WriteLine("ESCAPED from if "  + letter);
            } else {
                for (var m = number; m < word.Length; m++) {
                    Console.WriteLine("ESCAPED " + letter);
                    Recursion(word[m], word.Length - m, word, max, newWord);
                }
            }
        }
    }

}
