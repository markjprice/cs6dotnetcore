using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
namespace Ch08_EF7
{
    [Table("Categories")]
    public class Category
    {
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }
        public virtual ICollection<Product> Products { get; set; }
        public Category()
        {
            Products = new HashSet<Product>();
        }
    }
}
