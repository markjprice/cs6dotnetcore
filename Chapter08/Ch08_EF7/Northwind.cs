using Microsoft.Data.Entity;
namespace Ch08_EF7
{
    public class Northwind : DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\mssqllocaldb;initial catalog=Northwind;integrated security=true;");
            base.OnConfiguring(optionsBuilder);
        }
    }
}
