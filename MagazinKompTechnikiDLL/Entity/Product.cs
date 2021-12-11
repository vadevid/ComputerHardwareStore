using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MagazinKompTechniki.Entity
{
    public class Product
    {
        public int ID { get; set; }
        [Required] [MaxLength(50)] public string ProductName { get; set; }
        [Required] [MaxLength(50)] public string ProductType { get; set; }
        [Required] public double ProductCost { get; set; }
        [Required] [MaxLength(22)] public string SerialNumber { get; set; }

    }
}
