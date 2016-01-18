using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ch14_WebApp.Models
{
    public class HomeIndexViewModel
    {
        public int VisitorCount;
        public ICollection<Products> Products { get; set; }
    }
}
