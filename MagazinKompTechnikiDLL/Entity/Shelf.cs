using System;
using System.Collections.Generic;
using System.Text;

namespace MagazinKompTechniki.Entity
{
    public class Shelf
    {
        public int ID { get; set; }
        public string ProductModel { get; set; }
        public int Capacity { get; set; }
        public List<Product> Products { get; set; }
    }
}
