using System;
using System.Collections.Generic;
using System.Text;

namespace MagazinKompTechniki.Entity
{
    public class Compartment
    {
        public int ID { get; set; }
        public string ProductType { get; set; }
        public string Capacity { get; set; }
        public List<Rack> Racks { get; set; }
    }
}
