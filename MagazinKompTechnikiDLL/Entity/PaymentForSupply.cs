using System;
using System.Collections.Generic;
using System.Text;

namespace MagazinKompTechniki.Entity
{
    public class PaymentForSupply
    {
        public int ID { get; set; }
        public double DeliveryCost { get; set; }
        public Supply Supply { get; set; }
    }
}
