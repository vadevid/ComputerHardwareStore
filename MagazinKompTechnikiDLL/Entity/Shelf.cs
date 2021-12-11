using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MagazinKompTechniki.Entity
{
    public class Shelf
    {
        public int ID { get; set; }
        [Required] [MaxLength(50)] public string ProductModel { get; set; }
        [Required] public int Capacity { get; set; }
        [Required] public List<Product> Products { get; set; }
    }
}
