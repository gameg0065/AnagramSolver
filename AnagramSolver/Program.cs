using System;
using System.IO;
using Microsoft.Extensions.Configuration;
using System.Configuration;
using AnagramSolver.MyConsole;
using AnagramSolver.BusinessLogic;
using AnagramSolver.Contracts;

namespace AnagramSolver
{
    class Program
    {
        static void Main(string[] args) {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile(ConfigurationManager.AppSettings["Path"], optional: true, reloadOnChange: true);
            DictionaryManager.LoadDictionary(ConfigurationManager.AppSettings["DictionaryPath"]);
            int inputLength = Int32.Parse(builder.Build().GetSection("Settings").GetSection("MinimumLengthOfInput").Value);
            int anagramNumber = Int32.Parse(builder.Build().GetSection("Settings").GetSection("NumberOfAnagramsGenerated").Value);
            string userInput = GetUserInput.GetWord(inputLength);
            Output.PrintGeneratedAnagrams(AnagramGenerator.GenerateAnagrams(userInput, anagramNumber));
        }
    }
}
