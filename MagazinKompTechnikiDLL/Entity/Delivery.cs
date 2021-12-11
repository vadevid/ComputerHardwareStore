using System;
using System.Collections.Generic;
using System.Text;

namespace MagazinKompTechniki.Entity
{
    public class Delivery
    {
        public int ID { get; set; }
        public DateTime DeliveryDate { get; set; }
        public string DeliveryAddress { get; set; }
        public double DeliveryCost { get; set; }
        public bool NeedForDelivery { get; set; }
        public Employee Employee { get; set; }
        public Client Client { get; set; }
        public Order Order { get; set; }
    }
}
