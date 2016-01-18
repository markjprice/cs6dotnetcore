using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Ch14_WebApp.Models
{
    public partial class Products
    {
        public Products()
        {
            Order_Details = new HashSet<Order_Details>();
        }

        public int ProductID { get; set; }
        public int? CategoryID { get; set; }
        public bool Discontinued { get; set; }
        [Display(Name = "Product Name")]
        public string ProductName { get; set; }
        public string QuantityPerUnit { get; set; }
        public short? ReorderLevel { get; set; }
        public int? SupplierID { get; set; }
        [Display(Name = "Unit Price")]
        public decimal? UnitPrice { get; set; }
        [Display(Name = "Units In Stock")]
        public short? UnitsInStock { get; set; }
        public short? UnitsOnOrder { get; set; }

        public virtual ICollection<Order_Details> Order_Details { get; set; }
        public virtual Categories Category { get; set; }
        public virtual Suppliers Supplier { get; set; }
    }
}
