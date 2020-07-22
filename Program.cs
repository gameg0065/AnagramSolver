using System;
using System.IO;
using Microsoft.Extensions.Configuration;
using System.Configuration;

namespace AnagramSolver
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine($"The parameters are: {GetParameters()}");
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
