using System.Collections.Generic;

namespace AnagramSolver.Interfaces
{
    public interface IOutput
    {
        void PrintGeneratedAnagrams(Dictionary<string, string> anagrams);
    }
}
