using System.Collections.Generic;
using System.Linq;
using System;
using AnagramSolver.DAL;
using AnagramSolver.Models;
using System.Threading.Tasks;

namespace AnagramSolver.BusinessLogic
{
    public class AnagramGenerator
    {
        public async Task<List<string>> GenerateAnagrams(string word, int maxNumberOfAnagrams, string connString)
        {
            var codeFirstDataBase = new CodeFirstDataBase();
            var returned = await codeFirstDataBase.GetCachedWords(word, connString);
            if (returned.Count > 0)
            {
                return returned;
            }

            var generatedAnagrams = new List<string>();
            var entities = new List<WordEntity>();
            if (word.Length < 6)
            {
                var returnList = await FindAllCombinations(word);

                foreach (var item in returnList)
                {
                    var wordEntity = await Task.Run(() => codeFirstDataBase.CheckIfExistsInWords(item, connString));
                    if (wordEntity.Word != null && item != word && generatedAnagrams.Count < maxNumberOfAnagrams && !generatedAnagrams.Any(listItem => listItem == item))
                    {
                        generatedAnagrams.Add(item);
                        entities.Add(wordEntity);
                    }
                }
            }
            else
            {
                var orderedWord = word.ToCharArray();
                Array.Sort(orderedWord);
                var wordEntities = await Task.Run(() => codeFirstDataBase.CheckIfExistsInOrderedWords(new string(orderedWord), connString));
                foreach(var wordEntity in wordEntities) {
                    if ( wordEntity.Word != word && generatedAnagrams.Count < maxNumberOfAnagrams)
                    {
                        generatedAnagrams.Add(wordEntity.Word);
                        entities.Add(wordEntity);
                    }
                }
            }
            
            await codeFirstDataBase.AddToChaced(word, entities, connString);
            return generatedAnagrams;
        }
        private async Task<List<string>> FindAllCombinations(string word)
        {
            var returnList = new List<string>();
            for (int i = 0; i < word.Length; i++)
            {
                var test = word.Where(val => val != word[i]).ToArray();
                returnList.AddRange(await Task.Run(() => FindCombinatorially(test, word.Length, word[i].ToString())));
            }
            return returnList;
        }
        private async Task<List<string>> FindCombinatorially(char[] word, int wordLength, string answ)
        {
            var list = new List<string>();
            for (int i = 0; i < word.Length; i++)
            {
                answ += word[i];
                var items = Task.Run(() => FindCombinatorially(word.Where((val, idx) => idx != Array.IndexOf(word, word[i])).ToArray(), wordLength, answ));
                list.AddRange(await items);
                if (wordLength == answ.Length)
                {
                    list.Add(answ);
                }
                answ = answ.Remove(answ.Length - 1);
            }
            return list;
        }
    }
}
