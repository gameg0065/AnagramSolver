using System;
using System.Collections.Generic;
using AnagramSolver.Interfaces;

namespace AnagramSolver.UI
{
    public class Output: IOutput
    {
        public void PrintGeneratedAnagrams(List<string> anagrams)
        {
            Console.WriteLine();
            Console.WriteLine("Generated anagrams: ");
            foreach (var item in anagrams)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();
        } 
    }
}