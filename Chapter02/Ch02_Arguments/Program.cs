using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace Ch02_Arguments
{
    class Program
    {
        static void Main(string[] args)
        {
            ForegroundColor = (ConsoleColor)Enum.Parse(typeof(ConsoleColor), args[0], true);
            BackgroundColor = (ConsoleColor)Enum.Parse(typeof(ConsoleColor), args[1], true);
            WindowWidth = int.Parse(args[2]);
            WindowHeight = int.Parse(args[3]);

            WriteLine($"There are {args.Length} arguments.");
            foreach (string arg in args)
            {
                WriteLine(arg);
            }
        }
    }
}
