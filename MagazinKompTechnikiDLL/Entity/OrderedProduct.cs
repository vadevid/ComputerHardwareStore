using System;
using System.Collections.Generic;
using System.Text;

namespace MagazinKompTechniki.Entity
{
    public class OrderedProduct
    {
        public int ID { get; set; }
        public double OrderedProductCost { get; set; }
        public int NumberOfProducts { get; set; }
        public List<Product> Products { get; set; } 
        public Order Order { get; set; }
    }
}
