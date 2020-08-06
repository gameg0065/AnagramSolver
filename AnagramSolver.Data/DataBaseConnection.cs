using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.SqlClient;
using System.Data;
using AnagramSolver.Contracts;

namespace AnagramSolver.Data
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
            for(int i = 0; i < dictionary.Count; i++)
            {
                var item = dictionary.ElementAt(i);
                cmd.CommandText = "INSERT INTO Word (Word, Category) " + "VALUES ('" + item.Key.Replace("'", "''") + "', '" + item.Value.Antecedent + "')";
                cmd.ExecuteNonQuery();
            }
           
            cn.Close();
        }
        public bool CheckIfExists(string key)
        {
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = "Server=localhost;Database=anagramsolver; User Id = sa; Password = LAMA55lama;";
            cn.Open();

            SqlCommand checkWord = new SqlCommand("SELECT COUNT(*) FROM [Word] WHERE ([word] = @word)");
            checkWord.Connection = cn;
            checkWord.Parameters.AddWithValue("@word", key);
            var result = (int)checkWord.ExecuteScalar();
            cn.Close();
            return result > 0;
        }
    }
}
