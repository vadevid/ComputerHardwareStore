using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MagazinKompTechniki.Entity
{
    public class PaymentForSupply
    {
        public int ID { get; set; }
        [Required] public double DeliveryCost { get; set; }
        [Required] public Supply Supply { get; set; }
    }
}
