using System;
using System.Data.Entity.Infrastructure;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization.Formatters.Soap;
using System.Runtime.Serialization.Json;
using System.Xml;
using System.Xml.Serialization;
using static System.Console;

namespace Ch10_Exercise03
{
    class Program
    {
        static void Main(string[] args)
        {
            const string path = @"C:\Code\Chapter10\Exercise02\";

            Directory.CreateDirectory(path);

            try
            {
                var db = new Northwind();
                db.Configuration.ProxyCreationEnabled = false;
                DbQuery<Category> query = db.Categories.Include("Products");

                // create a local in-memory copy of the categories and related products
                Category[] results = query.ToArray();

                // 1. XmlSerializer
                string filenameXS = path + "CategoriesAndProductsXS.xml";
                TextWriter writerXS = File.CreateText(filenameXS);
                var serializerXS = new XmlSerializer(typeof(Category[]));
                serializerXS.Serialize(writerXS, results);
                writerXS.Dispose();

                //TextReader reader = File.OpenText(filenameXS);
                //Category[] categories = serializerXS.Deserialize(reader) as Category[];
                //foreach (Category c in categories)
                //{
                //    WriteLine($"{c.CategoryID}: {c.CategoryName} - {c.Description} has {c.Products.Count} products.");
                //}

                // 2. DataContractSerializer
                string filenameDCS = path + "CategoriesAndProductsDCS.xml";
                XmlWriter writerDCS = XmlWriter.Create(filenameDCS);
                var serializerDCS = new DataContractSerializer(typeof(Category[]));
                serializerDCS.WriteObject(writerDCS, results);
                writerDCS.Dispose();

                // 3. DataContractJsonSerializer
                string filenameDCJS = path + "CategoriesAndProductsDCJS.json";
                FileStream streamDCJS = File.Create(filenameDCJS);
                var serializerDCJS = new DataContractJsonSerializer(typeof(Category[]));
                serializerDCJS.WriteObject(streamDCJS, results);
                streamDCJS.Dispose();

                // 4. BinaryFormatter
                string filenameBF = path + "CategoriesAndProducts.bin";
                FileStream streamBF = File.Create(filenameBF);
                var serializerBF = new BinaryFormatter();
                serializerBF.Serialize(streamBF, results);
                streamBF.Dispose();

                // 5. SoapFormatter cannot serialize generic types!
                //string filenameSF = path + "CategoriesAndProducts.soap";
                //FileStream streamSF = File.Create(filenameSF);
                //var serializerSF = new SoapFormatter();
                //serializerSF.Serialize(streamSF, results);
                //streamSF.Dispose();

                
            }
            catch (Exception ex)
            {
                WriteLine($"{ex.GetType()}: {ex.Message}");
            }
        }
    }
}
