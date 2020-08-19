using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.SqlClient;
using System.Data;
using AnagramSolver.Contracts;
using AnagramSolver.Models;
using Microsoft.EntityFrameworkCore;

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
                    var word = new WordEntity { Word = item.Key, Category = item.Value.Antecedent };
                    db.WordEntities.Add(word);
                }
                db.SaveChanges();
            }
        }

        public void AddToChaced(string searchWord, List<WordEntity> wordEntities, string connString)
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
                db.SaveChanges();
            }
        }
        public WordEntity CheckIfExistsInWords(string key, string connString)
        {
            using (var db = new AnagramContext(connString))
            {
                var query = db.WordEntities.Where(s => s.Word == key);
                if(query.Count() <= 0 ) {
                    return new WordEntity();
                }
                return query.First();
            }
        }
        public List<string> GetCachedWords(string key, string connString)
        {
            var list = new List<string>();
            using (var db = new AnagramContext(connString))
            {
                var what = db.CachedWordEntities.Include(r => r.WordEntities).Where(s => s.SearchWord == key);
                if(what.Count() <= 0) {
                    return list;
                }
                CachedWordEntity query = what.First();
                foreach (var enrollment in query.WordEntities)
                {
                    Console.WriteLine("Enrollment ID: {0}, Course ID: {1}", enrollment.WordId, enrollment.Word);
                }
                list.Add(query.SearchWord);
            }
            return list;
        }
        public Dictionary<string, DictionaryEntry> FilterWords(string key, string connString)
        {
            var dictionary = new Dictionary<string, DictionaryEntry>();
        
            using (var db = new AnagramContext(connString))
            {
                var query = from WordEntity in db.WordEntities where WordEntity.Word.StartsWith(key) select WordEntity;
                foreach (var item in query)
                {
                    DictionaryEntry theElement = new DictionaryEntry();
                    theElement.Word = item.Word;
                    theElement.Antecedent = item.Category;
                    dictionary.Add(key: item.Word, value: theElement);
                }
            }
            return dictionary;
        }
        public void SaveUserLog(string ip, string searchWord, string connString)
        {
            using (var db = new AnagramContext(connString))
            {
                var userLogEntity = new UserLogEntity { UserIP = ip, LogDate =  DateTime.UtcNow};
                userLogEntity.CachedWordEntity = db.CachedWordEntities.First(s => s.SearchWord == searchWord);
                db.UserLogEntities.Add(userLogEntity);
                db.SaveChanges();
            }
        }
    }
}
