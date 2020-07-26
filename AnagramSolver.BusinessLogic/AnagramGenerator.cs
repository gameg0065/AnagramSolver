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
                Recursion(test[i], i + 1, test, 2);
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
        public char Recursion(char letter, int number, char[] word, int max) {
            Console.WriteLine("Input to function: " + max + " number :    " + letter + " " + number + " " + word);
            if(number < 0 || number > word.Length - 1 || max <= 0) {
                Console.WriteLine("ESCAPED");
                return letter;
            }
            max--;
            for (var m = number; m < word.Length; m++) {
                if(max == 0) {
                    // m = word.Length - 1;
                }
                Console.WriteLine("FUNCTION CALLED " + m + "  " + max);
                Recursion(word[m], word.Length - m, word, max);
            }
            return letter;
        }
    }

}
