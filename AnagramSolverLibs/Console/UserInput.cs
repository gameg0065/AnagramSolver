using System;

namespace AnagramSolver.MyConsole
{
    public static class GetUserInput
    {
        public static string GetWord(int minLength)
        {
            Console.WriteLine("Enter the word to generate anagram");
            string word = Console.ReadLine();
            while (word.Length < minLength)
            {
                Console.Write("This is not valid input. Please enter an valid word: ");
                word = Console.ReadLine();
            }
            return word;
        } 
    }
}