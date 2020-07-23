using System;
using System.IO;
using System.Collections.Generic;
using AnagramSolver.Contracts;

namespace AnagramSolver.BusinessLogic
{
    public static class DictionaryManager
    {

        private static Dictionary<string, Element> LoadDictionary() {
            var elements = new Dictionary<string, Element>();
            try
            {
                using (StreamReader sr = new StreamReader("./resources/zodynas.txt"))
                {
                    string line, lastWord = "";
                    while ((line = sr.ReadLine()) != null)
                    {
                        string[] words = line.Split('\t');
                        if (lastWord != words[0]) {
                            AddToDictionary(elements, words[0], words[1]);
                        }
                        lastWord = words[0];
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
            }
            return elements;
        }

        public static void IterateThruDictionary()
        {
            Dictionary<string, Element> elements = LoadDictionary();

            foreach (KeyValuePair<string, Element> kvp in elements)
            {
                Element theElement = kvp.Value;

            }
        }

        private static void AddToDictionary(Dictionary<string, Element> elements, string word, string antecedent)
        {
            Element theElement = new Element();

            theElement.Word = word;
            theElement.Antecedent = antecedent;

            elements.Add(key: theElement.Word, value: theElement);
        }
    }
}
