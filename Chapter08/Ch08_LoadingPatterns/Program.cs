using System;
using System.Linq;
using static System.Console;

namespace Ch08_LoadingPatterns
{
    class Program
    {
        static void Main(string[] args)
        {
            WriteLine("Loading Patterns with the Entity Framework");
            var db = new Northwind();
            IQueryable<Category> query;
            Write("Enable lazy-loading? (Y/N): ");
            var lazyloading = (ReadKey().Key == ConsoleKey.Y);
            db.Configuration.LazyLoadingEnabled = lazyloading;
            WriteLine();
            Write("Enable logging? (Y/N): ");
            var logging = (ReadKey().Key == ConsoleKey.Y);
            if (logging)
            {
                db.Database.Log = new Action<string>(message =>
                {
                    WriteLine(message);
                });
            }
            WriteLine();
            Write("Enable eager-loading? (Y/N): ");
            var eagerloading = (ReadKey().Key == ConsoleKey.Y);
            if (eagerloading)
            {
                query = db.Categories.Include("Products");
            }
            else
            {
                query = db.Categories;
            }
            WriteLine();
            Write("Enable explicit-loading? (Y/N): ");
            var explicitloading = (ReadKey().Key == ConsoleKey.Y);
            WriteLine();
            foreach (var item in query)
            {
                if (explicitloading)
                {
                    Write($"Explicitly load products for {item.CategoryName}? (Y/N): ");
                    if (ReadKey().Key == ConsoleKey.Y)
                    {
                        var products = db.Entry(item).Collection(c => c.Products);
                        if (!products.IsLoaded) products.Load();
                    }
                    WriteLine();
                }
                WriteLine($"{item.CategoryName} has {item.Products.Count} products.");
            }
        }
    }
}
