using System.Collections.Generic;

namespace AnagramSolver.Contracts
{
    public interface IAnagramSolver
    {
        Dictionary<string, string> GenerateAnagrams(string word, int maxNumberOfAnagrams);
    }
}
