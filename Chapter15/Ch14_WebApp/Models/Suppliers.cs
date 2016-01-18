using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Ch14_WebApp.Models
{
    public partial class Suppliers
    {
        public Suppliers()
        {
            Products = new HashSet<Products>();
        }

        public int SupplierID { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        [Display(Name = "Company Name")]
        public string CompanyName { get; set; }
        public string ContactName { get; set; }
        public string ContactTitle { get; set; }
        public string Country { get; set; }
        public string Fax { get; set; }
        public string HomePage { get; set; }
        public string Phone { get; set; }
        public string PostalCode { get; set; }
        public string Region { get; set; }

        public virtual ICollection<Products> Products { get; set; }
    }
}
