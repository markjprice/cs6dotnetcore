using System;
using System.Collections.Generic;

namespace Ch14_WebApp.Models
{
    public partial class Order_Details
    {
        public int OrderID { get; set; }
        public int ProductID { get; set; }
        public float Discount { get; set; }
        public short Quantity { get; set; }
        public decimal UnitPrice { get; set; }

        public virtual Orders Order { get; set; }
        public virtual Products Product { get; set; }
    }
}
