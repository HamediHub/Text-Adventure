using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CreateYourOwnAdventure.helper
{
    internal class InputHelper
    {

        private InputHelper()
        {
            throw new NotSupportedException("Cannot instantiate helper class 'InputHelper'");
        }

        public static int GetIntInput(int min, int max)
        {
            int input;

            do
            {
                try
                {
                    string inputLine;

                    do
                    {
                        OutputHelper.Print("Eingabe: ");
                        inputLine = Console.ReadLine();
                    } while (inputLine.Length == 0);
                    
                    input = Int32.Parse(inputLine.First().ToString());

                    if (input < min || input > max)
                    {
                        OutputHelper.ColorPrintLineNoReadKey("Ihre Eingabe liegt außerhalb des erlaubten Bereichs! (" + min + " - " + max + ")", ConsoleColor.Red);
                    }
                }
                catch (FormatException)
                {
                    OutputHelper.ColorPrintLineNoReadKey("Bitte geben Sie eine gültige Zahl ein!", ConsoleColor.Red);
                    input = min - 1; // Set input to an invalid value to continue the loop
                }

            } while (input < min || input > max);

            OutputHelper.PrintLineNoReadKey("");
            return input;
        }

        public static string GetNameInput()
        {
            string name = null;

            while (name == null)
            {
                OutputHelper.Print("Name: ");
                name = Console.ReadLine();

                if (name.Length < 1)
                {
                    OutputHelper.ColorPrintLineNoReadKey("Name darf nicht leer sein!", ConsoleColor.Red);
                    name = null;
                }
                else if (name.Length > 14)
                {
                    OutputHelper.ColorPrintLineNoReadKey("Name darf nicht länger als 14 Zeichen sein!", ConsoleColor.Red);
                    name = null;
                }
                else if (!Regex.IsMatch(name, "^\\w+$"))
                {
                    OutputHelper.ColorPrintLineNoReadKey("Name darf keine Sonderzeichen enthalten!", ConsoleColor.Red);
                    name = null;
                }

            }

            OutputHelper.PrintLineNoReadKey("");

            return name;

        }
    }
}
