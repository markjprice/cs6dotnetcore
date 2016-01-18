using System.Linq;
using static System.Console;

namespace Ch09_JoiningGrouping
{
    class Program
    {
        static void Main(string[] args)
        {
            var db = new Northwind();

            var categories = db.Categories.Select(c => new { c.CategoryID, c.CategoryName }).ToArray();
            var products = db.Products.Select(p => new { p.ProductID, p.ProductName, p.CategoryID }).ToArray();

            // join every product to its category to return 77 matches
            var queryJoin = categories.Join(products,
                category => category.CategoryID,
                product => product.CategoryID,
                (c, p) => new { c.CategoryName, p.ProductName, p.ProductID })
                .OrderBy(cp => cp.ProductID);

            foreach (var item in queryJoin)
            {
                WriteLine($"{item.ProductID}: {item.ProductName} is in {item.CategoryName}.");
            }

            // group all products by their category to return 8 matches
            var queryGroup = categories.GroupJoin(products,
                category => category.CategoryID,
                product => product.CategoryID,
                (c, Products) => new { c.CategoryName, Products = Products.OrderBy(p => p.ProductName) });

            foreach (var item in queryGroup)
            {
                WriteLine($"{item.CategoryName} has {item.Products.Count()} products.");
                foreach (var product in item.Products)
                {
                    WriteLine($"  {product.ProductName}");
                }
            }

        }
    }
}
