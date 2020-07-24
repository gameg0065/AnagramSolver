using System.Collections.Generic;

namespace AnagramSolver.Contracts
{
    public interface IOutput
    {
        void PrintGeneratedAnagrams(Dictionary<string, string> anagrams);
    }
}
