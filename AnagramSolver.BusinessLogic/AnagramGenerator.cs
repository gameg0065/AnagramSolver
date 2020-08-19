using System.Collections.Generic;
using AnagramSolver.Interfaces;
using System.Linq;
using System;
using AnagramSolver.DAL;
using AnagramSolver.Models;

namespace AnagramSolver.BusinessLogic
{
    public class AnagramGenerator
    {
        public List<string> GenerateAnagrams(string word, int maxNumberOfAnagrams, string connString)
        {
            var codeFirstDataBase = new CodeFirstDataBase();
            var returned = codeFirstDataBase.GetCachedWords(word, connString);
            if(returned.Count > 0) {
                Console.WriteLine("It works");
                return returned;
            }
            List<string> generatedAnagrams = new List<string>();
            List<string> returnList = new List<string>();
            for (int i = 0; i < word.Length; i++)
            {
                var test = word.Where(val => val != word[i]).ToArray();
                returnList = FindAllCombinations(test, word.ToCharArray(), word[i].ToString(), returnList);
            }
            var entities = new List<WordEntity>(); 
            foreach (var item in returnList) {
                var wordEntity = codeFirstDataBase.CheckIfExistsInWords(item, connString);
                if(wordEntity.Word != null && item != word && generatedAnagrams.Count < maxNumberOfAnagrams && !generatedAnagrams.Any(listItem => listItem == item)) {
                    generatedAnagrams.Add(item);
                    entities.Add(wordEntity);
                }
            }
            codeFirstDataBase.AddToChaced(word, entities, connString);
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
