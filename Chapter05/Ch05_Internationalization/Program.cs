using static System.Console;
using System;
using System.Threading;
using System.Globalization;

namespace Ch05_Internationalization
{
    class Program
    {
        static void Main(string[] args)
        {
            Thread t = Thread.CurrentThread;
            WriteLine($"The current globalization culture is {t.CurrentCulture.Name}: {t.CurrentCulture.DisplayName}");
            WriteLine($"The current localization culture is {t.CurrentUICulture.Name}: {t.CurrentUICulture.DisplayName}");
            WriteLine();
            WriteLine("en-US: English (United States)");
            WriteLine("da-DK: Danish (Denmark)");
            WriteLine("fr-CA: French (Canada)");
            Write("Enter an ISO culture code: ");
            string newculture = ReadLine();
            if (!string.IsNullOrEmpty(newculture))
            {
                var ci = new CultureInfo(newculture);
                Thread.CurrentThread.CurrentCulture = ci;
                Thread.CurrentThread.CurrentUICulture = ci;
            }
            Write($"{Prompts.EnterYourName} ");
            string name = ReadLine();
            Write($"{Prompts.EnterYourDOB} ");
            string dob = ReadLine();
            Write($"{Prompts.EnterYourSalary} ");
            string salary = ReadLine();
            WriteLine();
            DateTime date = DateTime.Parse(dob);
            int minutes = (int)DateTime.Today.Subtract(date).TotalMinutes;
            decimal earns = decimal.Parse(salary);
            WriteLine($"{name} was born on a {date:dddd} and is {minutes:N0} minutes old and earns {earns:C}.");

        }
    }
}
