using static System.Console;

namespace Ch02_Variables
{
    class Program
    {
        static void Main(string[] args)
        {
            var population = 66000000;
            var weight = 1.88; // in kilograms
            var price = 4.99M; // in pounds sterling
            var fruit = "Apples"; // strings use double-quotes
            var letter = 'Z'; // chars use single-quotes
            var happy = true;

            int ICannotBeNull = 4;
            ICannotBeNull = default(int); // 0
            int? ICouldBeNull = null;
            var result1 = ICouldBeNull.GetValueOrDefault(); // 0
            ICouldBeNull = 4;
            var result2 = ICouldBeNull.GetValueOrDefault(); // 4 

            // declaring the size of the array
            string[] names = new string[4];
            // storing items at index positions
            names[0] = "George";
            names[1] = "Jerry";
            names[2] = "Elaine";
            names[3] = "Cosmo";
            for (int i = 0; i < names.Length; i++)
            {
                WriteLine(names[i]); // read the item at this index
            }

            Write($"The population of the UK is {population}. ");
            WriteLine($"The population of the UK is {population:N0}. ");
            WriteLine($"{weight}kg of {fruit} costs {price:C}.");

            Write("Type your name and press ENTER: ");
            string name = ReadLine();
            Write("Type your age and press ENTER: ");
            string age = ReadLine();
            WriteLine($"Hello {name}, you look good for {age}.");
        }
    }
}
