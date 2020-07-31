using System.Collections.Generic;

namespace AnagramSolver.Interfaces
{
    public interface IAnagramSolver
    {
        List<string> GenerateAnagrams(string word, int maxNumberOfAnagrams);
        List<string> FindAllCombinations(char[] word, char[] originalWord, string answ, List<string> returnList);

    }
}
