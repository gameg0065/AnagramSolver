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
            Console.WriteLine(dictionary.Count);
            for(int i = 0; i < dictionary.Count; i++)
            {
                var item = dictionary.ElementAt(i);
                cmd.CommandText = "INSERT INTO Word (Word, Category) " + "VALUES ('" + item.Key.Replace("'", "''") + "', '" + item.Value.Antecedent + "')";
                cmd.ExecuteNonQuery();
            }
           
            cn.Close();
        }
    }
}
