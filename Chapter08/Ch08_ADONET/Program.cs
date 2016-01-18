using static System.Console;
using System.Data.SqlClient;
using System.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch08_ADONET
{
    class Program
    {
        static void Main(string[] args)
        {
            //var connection = new SqlConnection(@"Data Source=(localdb)\mssqllocaldb;Initial Catalog=Northwind;Integrated Security=true;");
            var connection = new SqlConnection(ConfigurationManager.ConnectionStrings["Northwind"].ConnectionString);
            connection.Open();
            WriteLine($"The connection is {connection.State}.");
            WriteLine("Original list of categories:");
            ListCategories(connection);

            Write("Enter a new category name: ");
            string name = ReadLine();
            // the category name column only allows up to 15 chars so truncate if necessary
            if (name.Length > 15) name = name.Substring(0, 15);

            var insertCategory = new SqlCommand($"INSERT INTO Categories(CategoryName) VALUES(@NewCategoryName)", connection);
            insertCategory.Parameters.AddWithValue("@NewCategoryName", name);
            int rowsAffected = insertCategory.ExecuteNonQuery();
            WriteLine($"{rowsAffected} row(s) were inserted.");

            WriteLine("List of categories after inserting:");
            ListCategories(connection);

            var deleteCategory = new SqlCommand($"DELETE FROM Categories WHERE CategoryName = @DeleteCategoryName", connection);
            deleteCategory.Parameters.AddWithValue("@DeleteCategoryName", name);
            rowsAffected = deleteCategory.ExecuteNonQuery();
            WriteLine($"{rowsAffected} row(s) were deleted.");

            WriteLine("List of categories after deleting:");
            ListCategories(connection);
            connection.Close();
            WriteLine($"The connection is {connection.State}.");
        }
        // a method we will call three times to list the categories
        private static void ListCategories(SqlConnection connection)
        {
            var getCategories = new SqlCommand("SELECT CategoryID, CategoryName FROM Categories", connection);

            SqlDataReader reader = getCategories.ExecuteReader();

            // find out the index positions of the columns that you want to read
            int indexOfID = reader.GetOrdinal("CategoryID");
            int indexOfName = reader.GetOrdinal("CategoryName");

            while (reader.Read())
            {
                // use the typed GetXxx methods to efficiently read the column values
                WriteLine($"{reader.GetInt32(indexOfID)}: {reader.GetString(indexOfName)}");
            }
            reader.Close();
        }
    }
}
