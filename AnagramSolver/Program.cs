using System;
using System.IO;
using Microsoft.Extensions.Configuration;
using System.Configuration;
using AnagramSolver.BusinessLogic;
using AnagramSolver.UI;
using AnagramSolver.Generic;

namespace AnagramSolver
{
    class Program
    {
        static void Main(string[] args) {
            // StartApp();
            // Console.WriteLine(CustomGeneric.MapIntToGender(2));
            Console.WriteLine(MapValueToEnum<Gender, int>.Map(2));
            Console.WriteLine(MapValueToEnum<Gender, string>.Map("Male"));
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
