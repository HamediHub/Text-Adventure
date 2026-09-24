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
            Console.WriteLine("min: " + min);
            Console.WriteLine("max: " + max);

            int input = min - 1;
            while (input < min || input > max)
            {
                input = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine(input);

                if (input < min || input > max)
                {
                    OutputHelper.ColorPrintLine("Eingabe muss im erlaubten Bereich (" + min + "-" + max + ") liegen!", ConsoleColor.Red);
                    input = min - 1;
                }
            }
            return input;
        }

        public static string GetNameInput()
        {
            string name = null;

            while (name == null)
            {
                name = Console.ReadLine();

                if (name.Length < 1)
                {
                    Console.WriteLine("Name darf nicht leer sein!");
                    name = null;
                }
                else if (name.Length > 14)
                {
                    Console.WriteLine("Name darf nicht länger als 14 Zeichen sein!");
                    name = null;
                }
                else if (!Regex.IsMatch(name, "^\\w+$"))
                {
                    Console.WriteLine("Name darf keine Sonderzeichen enthalten!");
                    name = null;
                }

            }

            return name;

        }
    }
}
