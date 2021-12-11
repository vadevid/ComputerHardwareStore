using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MagazinKompTechniki.Entity
{
    public class Order
    {
        public int ID { get; set; }
        [Required] public DateTime OrderDate { get; set; }
        [Required] public Employee Employee { get; set; }
        [Required] public Client Client { get; set; }

    }
}
