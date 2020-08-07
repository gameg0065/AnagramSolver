using System.Collections.Generic;
using AnagramSolver.Interfaces;
using System.Linq;
using System;

namespace AnagramSolver.BusinessLogic
{
    public class AnagramGenerator: IAnagramSolver
    {
        public List<string> GenerateAnagrams(string word, int maxNumberOfAnagrams)
        {
            var dataBase = new DataBase();
            if(dataBase.CheckIfExistsInCached(word)) {
                
                return dataBase.GetCachedWords(word);
            }

            List<string> generatedAnagrams = new List<string>();
            List<string> returnList = new List<string>();
            for (int i = 0; i < word.Length; i++)
            {
                var test = word.Where(val => val != word[i]).ToArray();
                returnList = FindAllCombinations(test, word.ToCharArray(), word[i].ToString(), returnList);
            }

            foreach (var item in returnList) {
                var index  = dataBase.CheckIfExistsInWords(item);
                if(index > 0 && item != word && generatedAnagrams.Count < maxNumberOfAnagrams && !generatedAnagrams.Any(listItem => listItem == item)) {
                    dataBase.AddToChaced(word, index);
                    generatedAnagrams.Add(item);
                }
            }
            return generatedAnagrams;
        }
         public List<string> FindAllCombinations(char[] word, char[] originalWord, string answ, List<string> returnList) {
            for (int i = 0; i < word.Length; i++)
            {
                answ += word[i];
                FindAllCombinations(word.Where((val, idx) => idx != Array.IndexOf(word, word[i])).ToArray(), originalWord, answ, returnList);
                if(originalWord.Length == answ.Length) {
                    returnList.Add(answ);
                }
                answ = answ.Remove(answ.Length - 1);
            }
            return returnList;
        }
    }
}
