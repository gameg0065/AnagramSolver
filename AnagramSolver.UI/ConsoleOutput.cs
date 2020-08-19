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
        public delegate void print(string s);
        public static void WriteToScreen(string str)
        {
            Console.WriteLine("The String is: {0}", str);
        }
        public static void WriteToDebug(string str)
        {
            Debug.WriteLine("The String is: {0}", str);
        }
        public static void WriteToFile(string s)
        {
            fs = new FileStream("../AnagramSolver.UI/files/message.txt",
            FileMode.Append, FileAccess.Write);
            sw = new StreamWriter(fs);
            sw.WriteLine(s);
            sw.Flush();
            sw.Close();
            fs.Close();
        }
        public static void sendString(print ps)
        {
            ps("Hello World");
        }
        public void PrintGeneratedAnagrams(List<string> anagrams)
        {
            print ps1 = new print(WriteToScreen);
            print ps2 = new print(WriteToDebug);
            print ps3 = new print(WriteToFile);
            sendString(ps1);
            sendString(ps2);
            sendString(ps3);
            Console.WriteLine();
            Console.WriteLine("Generated anagrams: ");
            foreach (var item in anagrams)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();
        } 
    }
}