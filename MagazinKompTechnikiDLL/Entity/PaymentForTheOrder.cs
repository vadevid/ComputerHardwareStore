using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MagazinKompTechniki.Entity
{
    public class PaymentForTheOrder
    {
        public int ID { get; set; }
        [Required] public double OrderCost { get; set; }
        [Required] public OrderedProduct OrderedProduct { get; set; }
    }
}
