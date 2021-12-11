using System;
using System.Collections.Generic;
using System.Text;

namespace MagazinKompTechniki.Entity
{
    public class Order
    {
        public int ID { get; set; }
        public DateTime OrderDate { get; set; }
        public Employee Employee { get; set; }
        public Client Client { get; set; }

    }
}
