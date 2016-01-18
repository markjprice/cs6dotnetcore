using Microsoft.Data.Entity;
using static System.Console;

namespace Ch08_EF7
{
    class Program
    {
        static void Main(string[] args)
        {
            var db = new Northwind();
            var query = db.Categories.Include(c => c.Products);
            foreach (var item in query)
            {
                WriteLine($"{item.CategoryName} has {item.Products.Count} products.");
            }
        }
    }
}
