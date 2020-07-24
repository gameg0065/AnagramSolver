using System;
using System.Collections.Generic;

namespace AnagramSolver.MyConsole
{
    public static class Output
    {
        public static void PrintGeneratedAnagrams(Dictionary<string, string> anagrams)
        {   
            Console.WriteLine("Generated anagrams: ");
            foreach (KeyValuePair<string, string> item in anagrams)
            {
                Console.WriteLine(item.Value);
            }
        } 
    }
}