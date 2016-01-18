using System.Windows;
using System.Data.SqlClient;

namespace Ch12_GUITasks
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private async void GetProductsButton_Click(object sender, RoutedEventArgs e)
        {
            var connection = new SqlConnection(@"Data Source=(localdb)\mssqllocaldb;Initial Catalog=Northwind;Integrated Security=true;");
            await connection.OpenAsync();
            var getProducts = new SqlCommand("WAITFOR DELAY '00:00:05';SELECT ProductID, ProductName, UnitPrice FROM Products", connection);
            SqlDataReader reader = await getProducts.ExecuteReaderAsync();
            int indexOfID = reader.GetOrdinal("ProductID");
            int indexOfName = reader.GetOrdinal("ProductName");
            int indexOfPrice = reader.GetOrdinal("UnitPrice");
            while (await reader.ReadAsync())
            {
                ProductsListBox.Items.Add($"{await reader.GetFieldValueAsync<int>(indexOfID)}: {await reader.GetFieldValueAsync<string>(indexOfName)} costs {await reader.GetFieldValueAsync<decimal>(indexOfPrice):C}");
            }
            reader.Dispose();
            connection.Dispose();
        }
    }
}
