using System;
using System.Collections.Generic;
using System.Text;

namespace MagazinKompTechniki.Entity
{
    public class Guarantee
    {
        public int ID { get; set; }
        public TimeSpan DurationOfTheGuarantee { get; set; }
        public DateTime GuaranteeDate { get; set; }
        public double GuaranteeCost { get; set; }
        public Order Order { get; set; }
    }
}
