using System;
using System.IO;
using Microsoft.Extensions.Configuration;
using System.Configuration;
using AnagramSolver.BusinessLogic;
using AnagramSolver.UI;
using AnagramSolver.Data;


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
            var myDictionaryManager = new DictionaryManager();
            myDictionaryManager.LoadDictionary(ConfigurationManager.AppSettings["DictionaryPath"]);
            var theGetUserInput = new GetUserInput();
            theGetUserInput.AskForUserInput(inputLength, anagramNumber);
        }
    }
}
