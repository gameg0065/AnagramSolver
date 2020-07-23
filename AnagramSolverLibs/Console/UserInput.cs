using System;

namespace AnagramSolver.MyConsole
{
    public static class GetUserInput
    {
        public static string GetName()
        {
            Console.WriteLine("Enter the word to generate anagram");
            string name = Console.ReadLine();
            return name;
        } 
    }
}