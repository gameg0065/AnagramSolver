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
            Console.WriteLine();
            Dictionary<string, string> generatedAnagrams = new Dictionary<string, string>();
            var q = word.Select(x => x.ToString());
            var test = word.ToCharArray();
            var original = word.ToCharArray();
            var test3 = word.ToCharArray();
            for (int i = 0; i < word.Length; i++)
            {
                Console.WriteLine("This line works here");
                Console.WriteLine();
                Console.WriteLine();
                test = original.Where(val => val != ' ').ToArray();
                test = test.Where(val => val != word[i]).ToArray();
                Console.WriteLine(word[i]);
                Recursion(test, test3);
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
        void Print(char[] s)
        {
            string test = new string(s);
            Console.WriteLine(test);
        }
        public void Recursion(char[] word, char[] originalWord) {
            // if(max - 1 >= 0) {
            //     max--;
            //     char temp = word[max];
            //     word[max] = word[max + 1];
            //     word[max + 1] = temp;
            //     string test1 = new string(word);
            //     for (int y = 0; y < 2; y++)
            //     {
            //         List<char[]> test3 = new List<char[]>();
            //         test3.Add(Switch(word));
            //         test3.ForEach(Print);
            //         test3.ForEach(delegate (char[] name) {
            //             Print(name);
            //             Recursion(name, max);
            //         });
            //         // string test = new string(word);
            //         // Console.WriteLine(test);
            //     }
            // }
            if(word.Length >= 0) {
                for (int i = 0; i < word.Length; i++)
                {
                    Console.WriteLine(word[i]);
                    Recursion(word.Where(val => val != word[i]).ToArray(), originalWord);
                    Console.WriteLine("test");
                }
            }

        }
        public char[] Switch(char[] word) {
            var last = word.Length - 1;
            char temp = word[last];
            word[last] = word[last - 1];
            word[last - 1] = temp;
            return word;
        }
        public char[] ShiftToRight(char[] word)
        {
            var last = word.Length - 1;
            char temp = word[last];
            for (int i = word.Length - 1; i > 0; i--) {
                word[i] = word[i - 1];
            }
            word[0] = temp;
            return word;
        }

    }

}
