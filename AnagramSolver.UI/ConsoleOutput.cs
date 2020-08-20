using System;
using System.Collections.Generic;
using AnagramSolver.Interfaces;
using System.Diagnostics;
using System.IO;
namespace AnagramSolver.UI
{
    public class Display : IDisplay
    {
        static FileStream fs;
        static StreamWriter sw;
        // public delegate void PrintDelegate(string s);
        // public static void WriteToScreen(string str)
        // {
        //     Console.WriteLine(str);
        // }
        // public static void WriteToDebug(string str)
        // {
        //     Debug.WriteLine(str);
        // }
        // public static string CapitalizeFirstLetter(string input)
        // {
        //     char[] letters = input.ToCharArray();
        //     letters[0] = char.ToUpper(letters[0]);
        //     return new string(letters);
        // }
        // public static void WriteToFile(string s)
        // {
        //     fs = new FileStream("../AnagramSolver.UI/files/message.txt",
        //     FileMode.Append, FileAccess.Write);
        //     sw = new StreamWriter(fs);
        //     sw.WriteLine(s);
        //     sw.Flush();
        //     sw.Close();
        //     fs.Close();
        // }
        // public static void sendString(PrintDelegate ps, string message)
        // {
        //     ps(message);
        // }

        public static Func<string, string> CapitalizeFirstLetter = str => {
            char[] letters = str.ToCharArray();
            letters[0] = char.ToUpper(letters[0]);
            return new string(letters);
        };

        Action<string> messageTarget;
        public void PrintGeneratedAnagrams(List<string> anagrams)
        {
            // PrintDelegate ps2 = new PrintDelegate(WriteToDebug);
            // PrintDelegate ps3 = new PrintDelegate(WriteToFile);
            // PrintDelegate ps = new PrintDelegate(WriteToScreen);

            Console.WriteLine();
            Console.WriteLine("Generated anagrams: ");
            foreach (var item in anagrams)
            {
                FormattedPrint(CapitalizeFirstLetter, item);
            }
            Console.WriteLine();
        }
        public void FormattedPrint(Func<string, string> myMethodName, string input) {
            string answ = myMethodName(input);
            messageTarget = Console.WriteLine;
            messageTarget(answ);
            // PrintDelegate ps = new PrintDelegate(WriteToScreen);
            // ps(answ);
        }
    }
}