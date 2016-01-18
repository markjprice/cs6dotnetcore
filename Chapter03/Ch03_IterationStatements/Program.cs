using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace Ch03_IterationStatements
{
    class Program
    {
        static void Main(string[] args)
        {
            //int x = 0;
            //while (x < 10)
            //{
            //    WriteLine(x);
            //    x++;
            //}

            int x = 0;
            do
            {
                WriteLine(x);
                x++;
            } while (x < 10);

            for (int y = 0; y < 10; y++)
            {
                WriteLine(y);
            }

            string[] names = { "Adam", "Barry", "Charlie" };
            foreach (string name in names)
            {
                WriteLine($"{name} has {name.Length} characters.");
            }

        }
    }
}
