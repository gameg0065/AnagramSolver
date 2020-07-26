using System.Collections.Generic;

namespace AnagramSolver.Interfaces
{
    public interface IAnagramSolver
    {
        Dictionary<string, string> GenerateAnagrams(string word, int maxNumberOfAnagrams);
    }
}
