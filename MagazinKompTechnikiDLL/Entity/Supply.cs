using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MagazinKompTechniki.Entity
{
    public class Supply
    {
        public int ID { get; set; }
        [Required] public DateTime SupplyDate { get; set; }
        [Required] public Manufacturer Manufacturer { get; set; }
    }
}
