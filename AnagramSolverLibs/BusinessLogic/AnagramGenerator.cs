using System.Collections.Generic;
using AnagramSolver.Contracts;
using System.Linq;

namespace AnagramSolver.BusinessLogic
{
    public class AnagramGenerator: IAnagramSolver
    {
        public Dictionary<string, string> GenerateAnagrams(string word, int maxNumberOfAnagrams)
        {
            Dictionary<string, string> generatedAnagrams = new Dictionary<string, string>();
            var q = word.Select(x => x.ToString());
            int size = word.Count();
            for (int i = 0; i < size - 1; i++) {
                q = q.SelectMany(x => word, (x, y) => x + y);
            }
            foreach (var item in q) {
                DictionaryManager theDictionaryManager = new DictionaryManager();
                if(theDictionaryManager.CheckIfExists(item) && item != word && !generatedAnagrams.ContainsKey(item) && generatedAnagrams.Count < maxNumberOfAnagrams) {
                    generatedAnagrams.Add(key: item, item);
                }
            }
            return generatedAnagrams;
        }
    }
}
