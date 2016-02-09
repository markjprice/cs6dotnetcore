using static System.Console;
using Packt.CS6;

namespace Ch07_ExtensionMethods
{
    class Program
    {
        static void Main(string[] args)
        {
            string email1 = "pamela@test.com";
            string email2 = "ian&test.com";

            WriteLine($"{email1} is a valid e-mail address: {MyExtensions.IsValidEmail(email1)}.");
            WriteLine($"{email2} is a valid e-mail address: {MyExtensions.IsValidEmail(email2)}.");

            WriteLine($"{email1} is a valid e-mail address: {email1.IsValidEmail()}.");
            WriteLine($"{email2} is a valid e-mail address: {email2.IsValidEmail()}.");

            // this will always call the instance method
            // NOT the extension method
            WriteLine($"{email1.Insert(2, "X")}");
        }
    }
}
