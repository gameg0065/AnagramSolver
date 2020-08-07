using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.SqlClient;
using System.Data;
using AnagramSolver.Contracts;
using System.Configuration;

namespace AnagramSolver.BusinessLogic
{
    public class DataBase
    {
        public static string connectionString;
        public void AddFromFile(Dictionary<string, DictionaryEntry> dictionary)
        {
            SqlConnection cn = new SqlConnection(connectionString);
            cn.Open();

            for (int i = 0; i < dictionary.Count; i++)
            {
                var item = dictionary.ElementAt(i);
                SqlCommand cmd = new SqlCommand("INSERT INTO Word (Word, Category) " + "VALUES ('" + item.Key.Replace("'", "''") + "', '" + item.Value.Antecedent + "')", cn);
                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();
            }

            cn.Close();
        }

        public void AddToChaced(string item, int index)
        {
            SqlConnection cn = new SqlConnection(connectionString);
            cn.Open();

            SqlCommand cmd = new SqlCommand("INSERT INTO CachedWord (searchWord, anagramId) " + "VALUES ('" + item.Replace("'", "''") + "', '" + index + "')", cn);
            cmd.CommandType = CommandType.Text;
            cmd.ExecuteNonQuery();

            cn.Close();
        }
        public int CheckIfExistsInWords(string key)
        {
            SqlConnection cn = new SqlConnection(connectionString);
            cn.Open();

            SqlCommand checkWord = new SqlCommand("SELECT * FROM Word WHERE word LIKE @word", cn);
            checkWord.Parameters.Add(new SqlParameter("word", key));
            SqlDataReader reader = checkWord.ExecuteReader();
            var index = 0;
            while (reader.Read())
            {
               index = reader.GetInt32(0);
            }

            cn.Close();
            return index;
        }

        public bool CheckIfExistsInCached(string key)
        {
            SqlConnection cn = new SqlConnection(connectionString);
            cn.Open();

            SqlCommand checkWord = new SqlCommand("SELECT COUNT(*) FROM [CachedWord] WHERE ([searchWord] = @word)", cn);
            checkWord.Parameters.AddWithValue("@word", key);
            var result = (int)checkWord.ExecuteScalar();

            cn.Close();

            return result > 0;
        }
        public List<string> GetCachedWords(string key)
        {
            SqlConnection cn = new SqlConnection(connectionString);
            
            cn.Open();

            SqlCommand checkWord = new SqlCommand("SELECT word, searchWord FROM Word, CachedWord WHERE  Word.id = CachedWord.anagramId; ", cn);
            SqlDataReader reader = checkWord.ExecuteReader();

            var list = new List<string>();

            while (reader.Read())
            {
                if(reader.GetString(1) == key) {
                    list.Add(reader.GetString(0));
                }
            }

            cn.Close();

            return list;
        }
        public Dictionary<string, DictionaryEntry> FilterWords(string key)
        {
            var dictionary = new Dictionary<string, DictionaryEntry>();
            SqlConnection cn = new SqlConnection(connectionString);
            cn.Open();

            SqlCommand checkWord = new SqlCommand("SELECT * FROM Word WHERE word LIKE @word", cn);
            checkWord.Parameters.Add(new SqlParameter("word", key + '%'));
            SqlDataReader reader = checkWord.ExecuteReader();

            while (reader.Read())
            {
                DictionaryEntry theElement = new DictionaryEntry();
                theElement.Word = reader.GetString(1);
                theElement.Antecedent = reader.GetString(2);
                dictionary.Add(key: reader.GetString(1), value: theElement);
            }

            cn.Close();
            return dictionary;
        }
        public void DeleteTable(string item)
        {
            SqlConnection cn = new SqlConnection(connectionString);
            cn.Open();

            SqlCommand cmd = new SqlCommand("DeleteTable", cn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@Tablename", SqlDbType.VarChar).Value = item;

            cmd.ExecuteNonQuery();
            cn.Close();
        }
        public void SaveUserLog(string ip, string item, List<string> anagrams)
        {
            SqlConnection cn = new SqlConnection(connectionString);
            cn.Open();
            for(int i = 0; i < anagrams.Count; i++) {
                SqlCommand cmd = new SqlCommand("INSERT INTO UserLog (userIp, searchTime, searchWord, anagram) " + "VALUES ('" +  ip + "', '" +  DateTime.UtcNow +  "', '" + item.Replace("'", "''") + "', '" + anagrams[i] + "')", cn);
                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();
            }

            cn.Close();
        }
    }
}
