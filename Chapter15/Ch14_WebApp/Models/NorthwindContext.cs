using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Metadata;

namespace Ch14_WebApp.Models
{
    public partial class NorthwindContext : DbContext
    {
        //protected override void OnConfiguring(DbContextOptionsBuilder options)
        //{
        //    options.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=Northwind;Trusted_Connection=True;");
        //}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Categories>(entity =>
            {
                entity.HasKey(e => e.CategoryID);

                entity.HasIndex(e => e.CategoryName).HasName("CategoryName");

                entity.Property(e => e.CategoryName)
                    .IsRequired()
                    .HasMaxLength(15);

                entity.Property(e => e.Description).HasColumnType("ntext");

                entity.Property(e => e.Picture).HasColumnType("image");
            });

            modelBuilder.Entity<CustomerCustomerDemo>(entity =>
            {
                entity.HasKey(e => new { e.CustomerID, e.CustomerTypeID });

                entity.Property(e => e.CustomerID)
                    .HasMaxLength(5)
                    .HasColumnType("nchar");

                entity.Property(e => e.CustomerTypeID)
                    .HasMaxLength(10)
                    .HasColumnType("nchar");

                entity.HasOne(d => d.Customer).WithMany(p => p.CustomerCustomerDemo).HasForeignKey(d => d.CustomerID).OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(d => d.CustomerType).WithMany(p => p.CustomerCustomerDemo).HasForeignKey(d => d.CustomerTypeID).OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<CustomerDemographics>(entity =>
            {
                entity.HasKey(e => e.CustomerTypeID);

                entity.Property(e => e.CustomerTypeID)
                    .HasMaxLength(10)
                    .HasColumnType("nchar");

                entity.Property(e => e.CustomerDesc).HasColumnType("ntext");
            });

            modelBuilder.Entity<Customers>(entity =>
            {
                entity.HasKey(e => e.CustomerID);

                entity.HasIndex(e => e.City).HasName("City");

                entity.HasIndex(e => e.Region).HasName("Region");

                entity.HasIndex(e => new { e.CompanyName }).HasName("CompanyName");

                entity.Property(e => e.CustomerID)
                    .HasMaxLength(5)
                    .HasColumnType("nchar");

                entity.Property(e => e.Address).HasMaxLength(60);

                entity.Property(e => e.City).HasMaxLength(15);

                entity.Property(e => e.CompanyName)
                    .IsRequired()
                    .HasMaxLength(40);

                entity.Property(e => e.ContactName).HasMaxLength(30);

                entity.Property(e => e.ContactTitle).HasMaxLength(30);

                entity.Property(e => e.Country).HasMaxLength(15);

                entity.Property(e => e.Fax).HasMaxLength(24);

                entity.Property(e => e.Phone).HasMaxLength(24);

                entity.Property(e => e.PostalCode).HasMaxLength(10);

                entity.Property(e => e.Region).HasMaxLength(15);
            });

            modelBuilder.Entity<EmployeeTerritories>(entity =>
            {
                entity.HasKey(e => new { e.EmployeeID, e.TerritoryID });

                entity.Property(e => e.TerritoryID).HasMaxLength(20);

                entity.HasOne(d => d.Employee).WithMany(p => p.EmployeeTerritories).HasForeignKey(d => d.EmployeeID).OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(d => d.Territory).WithMany(p => p.EmployeeTerritories).HasForeignKey(d => d.TerritoryID).OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<Employees>(entity =>
            {
                entity.HasKey(e => e.EmployeeID);

                entity.HasIndex(e => e.LastName).HasName("LastName");

                entity.Property(e => e.Address).HasMaxLength(60);

                entity.Property(e => e.BirthDate).HasColumnType("datetime");

                entity.Property(e => e.City).HasMaxLength(15);

                entity.Property(e => e.Country).HasMaxLength(15);

                entity.Property(e => e.Extension).HasMaxLength(4);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(10);

                entity.Property(e => e.HireDate).HasColumnType("datetime");

                entity.Property(e => e.HomePhone).HasMaxLength(24);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.Notes).HasColumnType("ntext");

                entity.Property(e => e.Photo).HasColumnType("image");

                entity.Property(e => e.PhotoPath).HasMaxLength(255);

                entity.Property(e => e.PostalCode).HasMaxLength(10);

                entity.Property(e => e.Region).HasMaxLength(15);

                entity.Property(e => e.Title).HasMaxLength(30);

                entity.Property(e => e.TitleOfCourtesy).HasMaxLength(25);

                entity.HasOne(d => d.ReportsToNavigation).WithMany(p => p.InverseReportsToNavigation).HasForeignKey(d => d.ReportsTo);
            });

            modelBuilder.Entity<Order_Details>(entity =>
            {
                entity.HasKey(e => new { e.OrderID, e.ProductID });

                entity.ToTable("Order Details");

                entity.HasIndex(e => e.OrderID).HasName("OrdersOrder_Details");

                entity.HasIndex(e => e.ProductID).HasName("ProductsOrder_Details");

                entity.Property(e => e.Discount).HasDefaultValue(0f);

                entity.Property(e => e.Quantity).HasDefaultValue(1);

                entity.Property(e => e.UnitPrice)
                    .HasColumnType("money")
                    .HasDefaultValue(0m);

                entity.HasOne(d => d.Order).WithMany(p => p.Order_Details).HasForeignKey(d => d.OrderID).OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(d => d.Product).WithMany(p => p.Order_Details).HasForeignKey(d => d.ProductID).OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<Orders>(entity =>
            {
                entity.HasKey(e => e.OrderID);

                entity.HasIndex(e => e.CustomerID).HasName("CustomersOrders");

                entity.HasIndex(e => e.EmployeeID).HasName("EmployeesOrders");

                entity.HasIndex(e => e.OrderDate).HasName("OrderDate");

                entity.HasIndex(e => e.ShipPostalCode).HasName("ShipPostalCode");

                entity.HasIndex(e => e.ShipVia).HasName("ShippersOrders");

                entity.HasIndex(e => e.ShippedDate).HasName("ShippedDate");

                entity.Property(e => e.CustomerID)
                    .HasMaxLength(5)
                    .HasColumnType("nchar");

                entity.Property(e => e.Freight)
                    .HasColumnType("money")
                    .HasDefaultValue(0m);

                entity.Property(e => e.OrderDate).HasColumnType("datetime");

                entity.Property(e => e.RequiredDate).HasColumnType("datetime");

                entity.Property(e => e.ShipAddress).HasMaxLength(60);

                entity.Property(e => e.ShipCity).HasMaxLength(15);

                entity.Property(e => e.ShipCountry).HasMaxLength(15);

                entity.Property(e => e.ShipName).HasMaxLength(40);

                entity.Property(e => e.ShippedDate).HasColumnType("datetime");

                entity.Property(e => e.ShipPostalCode).HasMaxLength(10);

                entity.Property(e => e.ShipRegion).HasMaxLength(15);

                entity.HasOne(d => d.Customer).WithMany(p => p.Orders).HasForeignKey(d => d.CustomerID);

                entity.HasOne(d => d.Employee).WithMany(p => p.Orders).HasForeignKey(d => d.EmployeeID);

                entity.HasOne(d => d.ShipViaNavigation).WithMany(p => p.Orders).HasForeignKey(d => d.ShipVia);
            });

            modelBuilder.Entity<Products>(entity =>
            {
                entity.HasKey(e => e.ProductID);

                entity.HasIndex(e => e.CategoryID).HasName("CategoryID");

                entity.HasIndex(e => e.ProductName).HasName("ProductName");

                entity.HasIndex(e => e.SupplierID).HasName("SuppliersProducts");

                entity.Property(e => e.Discontinued).HasDefaultValue(false);

                entity.Property(e => e.ProductName)
                    .IsRequired()
                    .HasMaxLength(40);

                entity.Property(e => e.QuantityPerUnit).HasMaxLength(20);

                entity.Property(e => e.ReorderLevel).HasDefaultValue(0);

                entity.Property(e => e.UnitPrice)
                    .HasColumnType("money")
                    .HasDefaultValue(0m);

                entity.Property(e => e.UnitsInStock).HasDefaultValue(0);

                entity.Property(e => e.UnitsOnOrder).HasDefaultValue(0);

                entity.HasOne(d => d.Category).WithMany(p => p.Products).HasForeignKey(d => d.CategoryID);

                entity.HasOne(d => d.Supplier).WithMany(p => p.Products).HasForeignKey(d => d.SupplierID);
            });

            modelBuilder.Entity<Region>(entity =>
            {
                entity.Property(e => e.RegionID).ValueGeneratedNever();

                entity.Property(e => e.RegionDescription)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnType("nchar");
            });

            modelBuilder.Entity<Shippers>(entity =>
            {
                entity.HasKey(e => e.ShipperID);

                entity.Property(e => e.CompanyName)
                    .IsRequired()
                    .HasMaxLength(40);

                entity.Property(e => e.Phone).HasMaxLength(24);
            });

            modelBuilder.Entity<Suppliers>(entity =>
            {
                entity.HasKey(e => e.SupplierID);

                entity.HasIndex(e => new { e.PostalCode }).HasName("PostalCode");

                entity.Property(e => e.Address).HasMaxLength(60);

                entity.Property(e => e.City).HasMaxLength(15);

                entity.Property(e => e.CompanyName)
                    .IsRequired()
                    .HasMaxLength(40);

                entity.Property(e => e.ContactName).HasMaxLength(30);

                entity.Property(e => e.ContactTitle).HasMaxLength(30);

                entity.Property(e => e.Country).HasMaxLength(15);

                entity.Property(e => e.Fax).HasMaxLength(24);

                entity.Property(e => e.HomePage).HasColumnType("ntext");

                entity.Property(e => e.Phone).HasMaxLength(24);

                entity.Property(e => e.PostalCode).HasMaxLength(10);

                entity.Property(e => e.Region).HasMaxLength(15);
            });

            modelBuilder.Entity<Territories>(entity =>
            {
                entity.HasKey(e => e.TerritoryID);

                entity.Property(e => e.TerritoryID).HasMaxLength(20);

                entity.Property(e => e.TerritoryDescription)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnType("nchar");

                entity.HasOne(d => d.Region).WithMany(p => p.Territories).HasForeignKey(d => d.RegionID).OnDelete(DeleteBehavior.Restrict);
            });
        }

        public virtual DbSet<Categories> Categories { get; set; }
        public virtual DbSet<CustomerCustomerDemo> CustomerCustomerDemo { get; set; }
        public virtual DbSet<CustomerDemographics> CustomerDemographics { get; set; }
        public virtual DbSet<Customers> Customers { get; set; }
        public virtual DbSet<EmployeeTerritories> EmployeeTerritories { get; set; }
        public virtual DbSet<Employees> Employees { get; set; }
        public virtual DbSet<Order_Details> Order_Details { get; set; }
        public virtual DbSet<Orders> Orders { get; set; }
        public virtual DbSet<Products> Products { get; set; }
        public virtual DbSet<Region> Region { get; set; }
        public virtual DbSet<Shippers> Shippers { get; set; }
        public virtual DbSet<Suppliers> Suppliers { get; set; }
        public virtual DbSet<Territories> Territories { get; set; }
    }
}