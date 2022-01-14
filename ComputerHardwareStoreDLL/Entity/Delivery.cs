using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MagazinKompTechniki.Entity
{
    public class Delivery
    {
        public int ID { get; set; }
        [Required] public DateTime DeliveryDate { get; set; }
        [Required] [MaxLength(50)] public string DeliveryAddress { get; set; }
        [Required] public double DeliveryCost { get; set; }
        [Required] public bool NeedForDelivery { get; set; }
        [Required] public Employee Employee { get; set; }
        [Required] public Client Client { get; set; }
    }
}
