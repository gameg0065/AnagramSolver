using System;
using System.IO;
using Microsoft.Extensions.Configuration;
using System.Configuration;
using AnagramSolver.BusinessLogic;
using AnagramSolver.UI;
using AnagramSolver.DAL;

namespace AnagramSolver
{
    class Program
    {
        static void Main(string[] args) {
            var codeFirstDataBase = new CodeFirstDataBase();
            var myDictionaryManager = new DictionaryManager();
            codeFirstDataBase.AddFromFile(myDictionaryManager.LoadDictionary(ConfigurationManager.AppSettings["DictionaryPath"]), "Server=localhost;Database=anagramsolver; User Id = sa; Password = LAMA55lama;");
            // StartApp();
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
