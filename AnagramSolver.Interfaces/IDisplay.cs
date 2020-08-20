using System.Collections.Generic;
using System;

namespace AnagramSolver.Interfaces
{
    public interface IDisplay
    {
        void PrintGeneratedAnagrams(List<string> anagrams);
        void FormattedPrint(Func<string, string> myMethodName, string input)
    }
}
