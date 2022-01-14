using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MagazinKompTechniki.Entity
{
    public class Guarantee
    {
        public int ID { get; set; }
        [Required] public TimeSpan DurationOfTheGuarantee { get; set; }
        [Required] public DateTime GuaranteeDate { get; set; }
        [Required] public double GuaranteeCost { get; set; }
        [Required] public Order Order { get; set; }
    }
}
