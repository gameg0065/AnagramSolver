using System;
using System.IO;
using Microsoft.Extensions.Configuration;
using System.Configuration;
using AnagramSolver.MyConsole;
using AnagramSolver.BusinessLogic;

namespace AnagramSolver
{
    class Program
    {
        static void Main(string[] args) {
            StartApp();
        }

        private static void StartApp() {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile(ConfigurationManager.AppSettings["Path"], optional: true, reloadOnChange: true);
            int inputLength = Int32.Parse(builder.Build().GetSection("Settings").GetSection("MinimumLengthOfInput").Value);
            int anagramNumber = Int32.Parse(builder.Build().GetSection("Settings").GetSection("NumberOfAnagramsGenerated").Value);
            DictionaryManager myDictionaryManager = new DictionaryManager();
            myDictionaryManager.LoadDictionary(ConfigurationManager.AppSettings["DictionaryPath"]);
            GetUserInput theGetUserInput = new GetUserInput();
            theGetUserInput.AskForUserInput(inputLength, anagramNumber);
        }
    }
}
