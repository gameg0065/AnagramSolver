using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.SqlClient;
using System.Data;
using AnagramSolver.Contracts;
using AnagramSolver.Models;

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

        // public void AddToChaced(string item, int index)
        // {
        //     SqlConnection cn = new SqlConnection(connectionString);
        //     cn.Open();

        //     SqlCommand cmd = new SqlCommand("INSERT INTO CachedWord (searchWord, anagramId) " + "VALUES ('" + item.Replace("'", "''") + "', '" + index + "')", cn);
        //     cmd.CommandType = CommandType.Text;
        //     cmd.ExecuteNonQuery();

        //     cn.Close();
        // }
        public int CheckIfExistsInWords(string key, string connString)
        {
            using (var db = new AnagramContext(connString))
            {
                var query = (from WordEntity in db.WordEntities where WordEntity.Word == key select WordEntity).Count();
                return query;
            }
        }

        // public bool CheckIfExistsInCached(string key)
        // {
        //     SqlConnection cn = new SqlConnection(connectionString);
        //     cn.Open();

        //     SqlCommand checkWord = new SqlCommand("SELECT COUNT(*) FROM [CachedWord] WHERE ([searchWord] = @word)", cn);
        //     checkWord.Parameters.AddWithValue("@word", key);
        //     var result = (int)checkWord.ExecuteScalar();

        //     cn.Close();

        //     return result > 0;
        // }
        // public List<string> GetCachedWords(string key)
        // {
        //     SqlConnection cn = new SqlConnection(connectionString);
            
        //     cn.Open();

        //     SqlCommand checkWord = new SqlCommand("SELECT word, searchWord FROM Word, CachedWord WHERE  Word.id = CachedWord.anagramId; ", cn);
        //     SqlDataReader reader = checkWord.ExecuteReader();

        //     var list = new List<string>();

        //     while (reader.Read())
        //     {
        //         if(reader.GetString(1) == key) {
        //             list.Add(reader.GetString(0));
        //         }
        //     }

        //     cn.Close();

        //     return list;
        // }
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
        // public void SaveUserLog(string ip, string item, List<string> anagrams)
        // {
        //     SqlConnection cn = new SqlConnection(connectionString);
        //     cn.Open();
        //     for(int i = 0; i < anagrams.Count; i++) {
        //         SqlCommand cmd = new SqlCommand("INSERT INTO UserLog (userIp, searchTime, searchWord, anagram) " + "VALUES ('" +  ip + "', '" +  DateTime.UtcNow +  "', '" + item.Replace("'", "''") + "', '" + anagrams[i] + "')", cn);
        //         cmd.CommandType = CommandType.Text;
        //         cmd.ExecuteNonQuery();
        //     }

        //     cn.Close();
        // }
    }
}
