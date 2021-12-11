using System;
using System.Collections.Generic;
using System.Text;

namespace MagazinKompTechniki.Entity
{
    public class Warehouse
    {
        public int ID { get; set; }
        public string WarehouseAdress { get; set; }
        public int Capacity { get; set; }
        public List<Compartment> Compartments { get; set; }
    }
}
