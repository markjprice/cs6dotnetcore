using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;
using System.Text.RegularExpressions;

namespace Ch04_Exercise02
{
    class Program
    {
        static void Main(string[] args)
        {
            WriteLine("The default regular expression checks for at least one digit.");
            Regex regex = new Regex(@"\d");
            do
            {
                Write("Enter a regular expression (or press ENTER to use the default): ");
                string regularExpression = ReadLine();
                try
                {
                    if (regularExpression != string.Empty)
                    {
                        regex = new Regex(regularExpression);
                    }
                    Write("Enter some input: ");
                    string input = ReadLine();
                    WriteLine($"{input} matches {regularExpression}? {regex.IsMatch(input)}");
                }
                catch (Exception ex)
                {
                    WriteLine($"{ex.GetType().Name}: {ex.Message}");
                }
                WriteLine("Press ESC to end or any key to try again.");
            } while (ReadKey(true).Key != ConsoleKey.Escape);
        }
    }
}
