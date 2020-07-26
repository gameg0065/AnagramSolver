using System.Collections.Generic;
using AnagramSolver.Contracts;


namespace AnagramSolver.Interfaces
{
    public interface IWordRepository
    {
        Dictionary<string, DictionaryEntry> LoadDictionary(string path);
        bool CheckIfExists(string key);
        void AddToDictionary(Dictionary<string, DictionaryEntry> dictionaryEntries, string word, string antecedent);
    }
}
