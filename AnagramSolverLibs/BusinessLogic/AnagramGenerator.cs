using System;
using System.IO;
using System.Collections.Generic;
using AnagramSolver.Contracts;
using System.Linq;

namespace AnagramSolver.BusinessLogic
{
    public static class AnagramGenerator
    {

        public static void GenerateAnagrams(string word)
        {
            var q = word.Select(x => x.ToString());
            int size = word.Count();
            for (int i = 0; i < size - 1; i++) {
                q = q.SelectMany(x => word, (x, y) => x + y);
            }
            foreach (var item in q) {
                if(DictionaryManager.CheckIfExists(item) && item != word) {
                    Console.WriteLine(item);
                }

            }
        }
    }
}
