using System;
using System.Collections.Generic;
using System.Text;

namespace MagazinKompTechniki.Entity
{
    public class Product
    {
        public int ID { get; set; }
        public string ProductName { get; set; }
        public string ProductType { get; set; }
        public double ProductCost { get; set; }
        public int SerialNumber { get; set; }

    }
}
