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
    public class DisplayWithEvents
    {
        public void PrintGeneratedAnagrams(List<string> anagrams)
        {
            var pub = new DisplayWithEvents();
            var sub1 = new Subscriber("printToConsole", pub);
            var sub2 = new Subscriber("printToFile", pub);

            Console.WriteLine();
            Console.WriteLine("Generated anagrams: ");
            foreach (var item in anagrams)
            {
                pub.OnRaiseCustomEvent(new CustomEventArgs("Event triggered"), item);
            }
            Console.WriteLine();

        }
        public event EventHandler<CustomEventArgs> RaiseCustomEvent;

        // Wrap event invocations inside a protected virtual method
        // to allow derived classes to override the event invocation behavior
        protected virtual void OnRaiseCustomEvent(CustomEventArgs e, string item)
        {
            EventHandler<CustomEventArgs> raiseEvent = RaiseCustomEvent;

            // Event will be null if there are no subscribers
            if (raiseEvent != null)
            {
                // Format the string to send inside the CustomEventArgs parameter
                e.Anagram = item;

                // Call to raise the event.
                raiseEvent(this, e);
            }
        }
    }
    class Subscriber
    {
        private readonly string _id;

        public Subscriber(string id, DisplayWithEvents pub)
        {
            _id = id;
            // Subscribe to the event
            pub.RaiseCustomEvent += HandleCustomEvent;
        }

        // Define what actions to take when the event is raised.
        void HandleCustomEvent(object sender, CustomEventArgs e)
        {
            if(_id == "printToConsole") {
                Console.WriteLine(e.Anagram);
            } else {
                FileStream fs;
                StreamWriter sw;
                fs = new FileStream("../AnagramSolver.UI/files/message.txt",
                FileMode.Append, FileAccess.Write);
                sw = new StreamWriter(fs);
                sw.WriteLine(e.Anagram);
                sw.Flush();
                sw.Close();
                fs.Close();
            }
        }
    }

    public class CustomEventArgs : EventArgs
    {
        public CustomEventArgs(string anagram)
        {
            Anagram = anagram;
        }
        public string Anagram { get; set; }
    }
}