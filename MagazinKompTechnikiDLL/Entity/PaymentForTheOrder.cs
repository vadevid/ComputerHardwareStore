using System;
using System.Collections.Generic;
using System.Text;

namespace MagazinKompTechniki.Entity
{
    public class PaymentForTheOrder
    {
        public int ID { get; set; }
        public double OrderCost { get; set; }
        public OrderedProduct OrderedProduct { get; set; }
    }
}
