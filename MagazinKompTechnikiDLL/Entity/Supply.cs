using System;
using System.Collections.Generic;
using System.Text;

namespace MagazinKompTechniki.Entity
{
    public class Supply
    {
        public int ID { get; set; }
        public DateTime SupplyDate { get; set; }
        public Manufacturer Manufacturer { get; set; }
    }
}
