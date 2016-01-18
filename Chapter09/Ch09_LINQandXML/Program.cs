using System.Linq;
using System.Xml.Linq;
using static System.Console;

namespace Ch09_LINQandXML
{
    class Program
    {
        static void Main(string[] args)
        {
            var db = new Northwind();
            var products = db.Products.ToArray();
            var xml = new XElement("products",
                            from p in products
                            select new XElement("product",
                                new XAttribute("id", p.ProductID),
                                new XAttribute("price", p.UnitPrice),
                                new XElement("name", p.ProductName)));
            WriteLine(xml.ToString());

        }
    }
}
