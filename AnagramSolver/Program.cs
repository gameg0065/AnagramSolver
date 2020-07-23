using System;
using System.IO;
using Microsoft.Extensions.Configuration;
using System.Configuration;
using AnagramSolver.Consoleno;
using AnagramSolver.BusinessLogic;

namespace AnagramSolver
{
    class Program
    {
        static void Main(string[] args)
        {
            // DictionaryManager.loadDictionary(ConfigurationManager.AppSettings["DictionaryPath"]);
            DictionaryManager.IterateThruDictionary();
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
