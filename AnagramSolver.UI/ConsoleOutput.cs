using System;
using System.Collections.Generic;
using AnagramSolver.Interfaces;

namespace AnagramSolver.UI
{
    public class Output: IOutput
    {
        public void PrintGeneratedAnagrams(Dictionary<string, string> anagrams)
        {
            Console.WriteLine();
            Console.WriteLine("Generated anagrams: ");
            foreach (KeyValuePair<string, string> item in anagrams)
            {
                Console.WriteLine(item.Value);
            }
            Console.WriteLine();
        } 
    }
}