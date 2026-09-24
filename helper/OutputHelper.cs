using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreateYourOwnAdventure.helper
{
    internal class OutputHelper
    {
        private OutputHelper()
        {
            throw new NotSupportedException("Cannot instantiate helper class 'OutputHelper'");
        }

        public static void PrintLine(string s)
        {
            Console.WriteLine(s);
            Console.ReadKey();
        }

        public static void PrintLineNoReadKey(string s)
        {
            Console.WriteLine(s);
        }

        public static void Print(string s)
        {
            Console.Write(s);
        }

        public static void ColorPrintLine(string s, ConsoleColor color)
        {
            ConsoleColor oldColor = Console.ForegroundColor;
            Console.ForegroundColor = color;
            Console.WriteLine(s);
            Console.ForegroundColor = oldColor;
            Console.ReadKey();
        }
        public static void ColorPrintLineNoReadKey(string s, ConsoleColor color)
        {
            ConsoleColor oldColor = Console.ForegroundColor;
            Console.ForegroundColor = color;
            Console.WriteLine(s);
            Console.ForegroundColor = oldColor;
        }

        public static void ColorPrint(string s, ConsoleColor color)
        {
            ConsoleColor oldColor = Console.ForegroundColor;
            Console.ForegroundColor = color;
            Console.Write(s);
            Console.ForegroundColor = oldColor;
        }
    }
}
