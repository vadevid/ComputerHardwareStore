using System.ComponentModel.DataAnnotations;

namespace MagazinKompTechniki.Entity
{
    public class PaymentForSupply
    {
        public int ID { get; set; }
        [Required] public double DeliveryCost { get; set; }
        [Required] public virtual Supply Supply { get; set; }
    }
}
