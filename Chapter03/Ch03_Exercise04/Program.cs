using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace Ch03_Exercise04
{
    class Program
    {
        static void Main(string[] args)
        {
            Write("Enter a number between 1 and 255: ");
            string n1 = ReadLine();
            Write("Enter another number between 1 and 255: ");
            string n2 = ReadLine();

            try
            {
                byte a = byte.Parse(n1);
                byte b = byte.Parse(n2);
                var answer = a / b;
                WriteLine($"{a} divided by {b} is {answer}");
            }
            catch (Exception ex)
            {
                WriteLine($"{ex.GetType().Name}: {ex.Message}");
            }
        }
    }
}
