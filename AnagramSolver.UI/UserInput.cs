using System;
using AnagramSolver.Interfaces;
using AnagramSolver.BusinessLogic;
using System.Collections.Generic;
namespace AnagramSolver.UI
{
    public class GetUserInput: IUserInteraction
    {
        public void AskForUserInput(int minLength, int anagramNumber)
        {
            bool endApp = false;
            Console.WriteLine("Console Anagram Generator in C#\r");
            Console.WriteLine("------------------------\n");

            while (!endApp)
            {
                string word = GetWord(minLength);
                AnagramGenerator myAnagramGenerator = new AnagramGenerator();
                var display = new Display();
                display.PrintGeneratedAnagrams(new List<string>());
                endApp = AskToEndApp();
            }      
        }
        public string GetWord(int minLength)
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
        public bool AskToEndApp()
        {
            bool endApp = false;
            Console.Write("Press 'n' and Enter to close the app, or press any other key and Enter to continue: ");

            if (Console.ReadLine() == "n")
            {
                endApp = true;
            }
            return endApp;
        }
    }
}