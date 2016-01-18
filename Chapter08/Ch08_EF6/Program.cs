using static System.Console;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch08_EF6
{
    class Program
    {
        static void Main(string[] args)
        {
            WriteLine("List of products that cost more than a given price with most expensive first.");
            string input;
            decimal price;
            do
            {
                Write("Enter a product price: ");
                input = ReadLine();
            } while (!decimal.TryParse(input, out price));

            var db = new Northwind();
            // if you manually open a connection it will stop 
            // automatically opening and closing constantly
            db.Database.Connection.Open();

            db.Database.Log = new Action<string>(message => { WriteLine(message); });

            var query = db.Products
                .Where(product => product.UnitPrice > price)
                .OrderByDescending(product => product.UnitPrice);
            //WriteLine(query.ToString());
            foreach (var item in query)
            {
                WriteLine($"{item.ProductID}: {item.ProductName} costs {item.UnitPrice:$#,##0.00}");
            }

            var newProduct = new Product
            {
                ProductName = "Bob's Burger",
                UnitPrice = 500M
            };
            // mark product as added in change tracking
            db.Products.Add(newProduct);
            // save tracked changes to database
            db.SaveChanges();
            foreach (var item in query)
            {
                WriteLine($"{item.ProductID}: {item.ProductName} costs {item.UnitPrice:$#,##0.00}");
            }

            var updateProduct = db.Products.Find(78);
            updateProduct.UnitPrice += 20M;
            db.SaveChanges();
            foreach (var item in query)
            {
                WriteLine($"{item.ProductID}: {item.ProductName} costs {item.UnitPrice:$#,##0.00}");
            }
            db.Database.Connection.Close();
        }
    }
}
