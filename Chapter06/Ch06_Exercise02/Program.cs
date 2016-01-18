using static System.Console;

namespace Ch06_Exercise02
{
    class Program
    {
        static string IntegerToOrdinal(int i)
        {
            // these are exceptions to the general rule
            if (i == 11) return "11th";
            if (i == 12) return "12th";
            if (i == 13) return "13th";

            // implementation of the general rule requires checking the last digit
            string number = i.ToString();
            char lastDigit = number[number.Length - 1];

            switch (lastDigit)
            {
                case '1':
                    return string.Format("{0}st", number);
                case '2':
                    return string.Format("{0}nd", number);
                case '3':
                    return string.Format("{0}rd", number);
                default:
                    return string.Format("{0}th", number);
            }
        }

        static int Factorial(int n)
        {
            if (n == 0) return 1;
            return n * Factorial(n - 1);
        }

        static string PrimeFactors(int n)
        {
            return "Not implemented";
        }

        static void Main(string[] args)
        {
            WriteLine("Test the IntegerToOrdinal method by looping through 1 to 50");

            for (int i = 1; i < 50; i++)
            {
                Write("{0}, ", IntegerToOrdinal(i));
            }
            WriteLine("{0}", IntegerToOrdinal(50));
            WriteLine();

            WriteLine("Test the Factorial method");

            for (int i = 1; i <= 10; i++)
            {
                WriteLine("{0}! = {1}", i, Factorial(i));
            }
            WriteLine();

            WriteLine("Test the PrimeFactors method");

            Write("Enter a whole number to generate the prime factors of: ");
            int number = int.Parse(ReadLine());
            WriteLine($"The prime factors of {number} are {PrimeFactors(number)}.");
            WriteLine();

            WriteLine("Press ENTER to end.");
            ReadLine();
        }
    }
}
