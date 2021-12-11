using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MagazinKompTechniki.Entity
{
    public class OrderedProduct
    {
        public int ID { get; set; }
        [Required] public double OrderedProductCost { get; set; }
        [Required] public int NumberOfProducts { get; set; }
        [Required] public List<Product> Products { get; set; }
        [Required] public Order Order { get; set; }
    }
}
