using System;
using System.IO;
using System.Collections.Generic;
using AnagramSolver.Contracts;

namespace AnagramSolver.BusinessLogic
{
    public class DictionaryManager : IWordRepository
    {
        public static Dictionary<string, DictionaryEntry> dictionaryEntries = new Dictionary<string, DictionaryEntry>();
        public Dictionary<string, DictionaryEntry> LoadDictionary(string path) {
            if(dictionaryEntries.Count == 0) {
                try
                {
                    using (StreamReader sr = new StreamReader(path))
                    {
                        string line;
                        while ((line = sr.ReadLine()) != null)
                        {
                            string[] words = line.Split('\t');
                            if (!dictionaryEntries.ContainsKey(words[0]))
                            {
                                AddToDictionary(dictionaryEntries, words[0], words[1]);
                            }
                        }
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("The file could not be read:");
                    Console.WriteLine(e.Message);
                }
            }
            return dictionaryEntries;
        }

        public bool CheckIfExists(string key)
        {
            bool exists = false;
            if (DictionaryManager.dictionaryEntries.ContainsKey(key))
            {
                exists = true;
            }
            return exists;
        }

        public void AddToDictionary(Dictionary<string, DictionaryEntry> elements, string word, string antecedent)
        {
            DictionaryEntry theElement = new DictionaryEntry();

            theElement.Word = word;
            theElement.Antecedent = antecedent;

            elements.Add(key: theElement.Word, value: theElement);
        }
    }
}
