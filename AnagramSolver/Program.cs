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
            DictionaryManager.LoadDictionary(ConfigurationManager.AppSettings["DictionaryPath"]);
            Console.WriteLine(GetUserInput.GetName());
            // Console.WriteLine(DictionaryManager.CheckIfExists("Jonas"));

        }
        private static string GetParameters()
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile(ConfigurationManager.AppSettings["Path"], optional: true, reloadOnChange: true);
            var val1 = builder.Build().GetSection("Settings").GetSection("NumberOfAnagramsGenerated").Value;
            var val2 = builder.Build().GetSection("Settings").GetSection("MinimumLengthOfInput").Value;

            return $"The values of parameters are: {val1} and {val2}";
        }
    }
}
