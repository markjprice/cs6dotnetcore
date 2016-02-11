using System.Linq;
using static System.Console;

namespace Ch09_LinqToObjects
{
    class Program
    {
        static void Main(string[] args)
        {
            var names = new string[] { "Michael", "Pam", "Jim", "Dwight", "Angela", "Kevin", "Toby", "Creed" };
            //var query = names.Where(new Func<string, bool>(NameLongerThanFour));
            //var query = names.Where(NameLongerThanFour);

            var query = names
                .ProcessSequence()
                .Where(name => name.Length > 4)
                .ProcessSequence()
                .OrderBy(name => name.Length)
                .ThenBy(name => name);

            foreach (var item in query)
            {
                WriteLine(item);
            }
        }
        static bool NameLongerThanFour(string name)
        {
            return name.Length > 4;
        }
    }
}
