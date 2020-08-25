using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using AnagramSolver.Contracts;
using AnagramSolver.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace AnagramSolver.DAL
{
    public class CodeFirstDataBase
    {
        public void AddFromFile(Dictionary<string, DictionaryEntry> dictionary, string connString)
        {
            using (var db = new AnagramContext(connString))
            {
                for (int i = 0; i < dictionary.Count; i++)
                {
                    var item = dictionary.ElementAt(i);
                    var word = new WordEntity { Word = item.Key, OrderedWord = item.Value.Word, Category = item.Value.Antecedent };
                    db.WordEntities.Add(word);
                }
                db.SaveChanges();
            }
        }

        public async Task AddToChaced(string searchWord, List<WordEntity> wordEntities, string connString)
        {
            using (var db = new AnagramContext(connString))
            {
                var cachedWordEntity = new CachedWordEntity {
                    SearchWord = searchWord,
                };

                foreach (var item in wordEntities)
                {
                    cachedWordEntity.WordEntities.Add(db.WordEntities.FirstOrDefault(m => m.WordId == item.WordId));
                }

                db.CachedWordEntities.Add(cachedWordEntity);
                await db.SaveChangesAsync();
            }
        }
        public async Task<WordEntity> CheckIfExistsInWords(string key, string connString)
        {
            using (var db = new AnagramContext(connString))
            {
                var query = await db.WordEntities.Where(s => s.Word == key).ToListAsync();
                if(query.Count() <= 0 ) {
                    return new WordEntity();
                }
                return query.First();
            }
        }
        public async Task<List<WordEntity>> CheckIfExistsInOrderedWords(string key, string connString)
        {
            using (var db = new AnagramContext(connString))
            {
                var query = await db.WordEntities.Where(s => s.OrderedWord == key).ToListAsync();
                if (query.Count() <= 0)
                {
                    return new List<WordEntity>();
                }
                return query;
            }
        }
        public async Task<List<string>> GetCachedWords(string key, string connString)
        {
            var list = new List<string>();
            using (var db = new AnagramContext(connString))
            {
                var result = await db.CachedWordEntities.Include(r => r.WordEntities).Where(s => s.SearchWord == key).ToListAsync();
                if(result.Count() <= 0) {
                    return list;
                }
                foreach (var wordEntity in result.Last().WordEntities)
                {
                    if(key != wordEntity.Word) {
                        list.Add(wordEntity.Word);
                    }
                }
            }
            return list;
        }
        public async Task<Dictionary<string, DictionaryEntry>> FilterWords(string key, string connString)
        {
            var dictionary = new Dictionary<string, DictionaryEntry>();
        
            using (var db = new AnagramContext(connString))
            {
                var query = await db.WordEntities.Where(s => s.Word.StartsWith(key)).ToListAsync();
                foreach (var item in query)
                {
                    var element = new DictionaryEntry();
                    element.Word = item.OrderedWord;
                    element.Antecedent = item.Category;
                    dictionary.Add(key: item.Word, value: element);
                }
            }
            return dictionary;
        }
        public async Task<Dictionary<string, DictionaryEntry>> GetWords(int key, int numberOfItemsToReturn, string connString)
        {
            var dictionary = new Dictionary<string, DictionaryEntry>();

            using (var db = new AnagramContext(connString))
            {
                var query = await db.WordEntities.Skip(numberOfItemsToReturn * (key - 1)).Take(numberOfItemsToReturn * key).ToListAsync();
                foreach (var item in query)
                {
                    var element = new DictionaryEntry();
                    element.Word = item.OrderedWord;
                    element.Antecedent = item.Category;
                    dictionary.Add(key: item.Word, value: element);
                }
            }
            return dictionary;
        }
        public async Task SaveUserLog(string ip, string searchWord, string connString)
        {
            using (var db = new AnagramContext(connString))
            {
                var userLogEntity = new UserLogEntity { UserIP = ip, LogDate =  DateTime.UtcNow};
                userLogEntity.CachedWordEntity = db.CachedWordEntities.First(s => s.SearchWord == searchWord);
                db.UserLogEntities.Add(userLogEntity);
                await db.SaveChangesAsync();
            }
        }
    }
}
