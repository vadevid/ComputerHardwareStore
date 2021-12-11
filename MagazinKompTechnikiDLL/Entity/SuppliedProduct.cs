using System;
using System.Collections.Generic;
using System.Text;

namespace MagazinKompTechniki.Entity
{
    public class SuppliedProduct
    {
        public int ID { get; set; }
        public double SupplyCost { get; set; }
        public int NumberOFProducts { get; set; }
        public List<Product> Products { get; set; }
        public List<Supply> Supplies { get; set; }
    }
}
