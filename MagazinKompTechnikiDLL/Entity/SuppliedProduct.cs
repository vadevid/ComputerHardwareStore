using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MagazinKompTechniki.Entity
{
    public class SuppliedProduct
    {
        public int ID { get; set; }
        [Required] public double SupplyCost { get; set; }
        [Required] public int NumberOFProducts { get; set; }
        [Required] public List<Product> Products { get; set; }
        [Required] public List<Supply> Supplies { get; set; }
    }
}
