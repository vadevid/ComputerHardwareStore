using System;
using System.Collections.Generic;
using System.Text;

namespace MagazinKompTechniki.Entity
{
    public class Rack
    {
        public int ID { get; set; }
        public string Manufacturer { get; set; }
        public int Capacity { get; set; }

        public List<Shelf> Shelves { get; set; }
    }
}
