using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MagazinKompTechniki.Entity
{
    public class Rack
    {
        public int ID { get; set; }
        [Required] [MaxLength(50)] public string Manufacturer { get; set; }
        [Required] public int Capacity { get; set; }

        [Required] public List<Shelf> Shelves { get; set; }
    }
}
