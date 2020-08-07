using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.SqlClient;
using System.Data;
using AnagramSolver.Contracts;

namespace AnagramSolver.BusinessLogic
{
    public class DataBase
    {
        public void AddFromFile(Dictionary<string, DictionaryEntry> dictionary)
        {
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = "Server=localhost;Database=anagramsolver; User Id = sa; Password = LAMA55lama;";
            cn.Open();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cn;
            cmd.CommandType = CommandType.Text;
            for (int i = 0; i < dictionary.Count; i++)
            {
                var item = dictionary.ElementAt(i);
                cmd.CommandText = "INSERT INTO Word (Word, Category) " + "VALUES ('" + item.Key.Replace("'", "''") + "', '" + item.Value.Antecedent + "')";
                cmd.ExecuteNonQuery();
            }

            cn.Close();
        }

        public void AddToChaced(string item, int index)
        {
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = "Server=localhost;Database=anagramsolver; User Id = sa; Password = LAMA55lama;";
            cn.Open();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cn;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "INSERT INTO CachedWord (searchWord, anagramId) " + "VALUES ('" + item.Replace("'", "''") + "', '" + index + "')";
            cmd.ExecuteNonQuery();

            cn.Close();
        }
        public int CheckIfExistsInWords(string key)
        {
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = "Server=localhost;Database=anagramsolver; User Id = sa; Password = LAMA55lama;";
            cn.Open();

            SqlCommand checkWord = new SqlCommand("SELECT * FROM Word WHERE word LIKE @word");
            checkWord.Connection = cn;
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
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = "Server=localhost;Database=anagramsolver; User Id = sa; Password = LAMA55lama;";
            cn.Open();

            SqlCommand checkWord = new SqlCommand("SELECT COUNT(*) FROM [CachedWord] WHERE ([searchWord] = @word)");
            checkWord.Connection = cn;
            checkWord.Parameters.AddWithValue("@word", key);
            var result = (int)checkWord.ExecuteScalar();
            cn.Close();
            return result > 0;
        }
        public List<string> GetCachedWords(string key)
        {
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = "Server=localhost;Database=anagramsolver; User Id = sa; Password = LAMA55lama;";
            
            cn.Open();

            SqlCommand checkWord = new SqlCommand("SELECT word, searchWord FROM Word, CachedWord WHERE  Word.id = CachedWord.anagramId; ");
            checkWord.Connection = cn;
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
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = "Server=localhost;Database=anagramsolver; User Id = sa; Password = LAMA55lama;";
            cn.Open();

            SqlCommand checkWord = new SqlCommand("SELECT * FROM Word WHERE word LIKE @word");
            checkWord.Connection = cn;
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
    }
}
