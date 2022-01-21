using MagazinKompTechnikiDLL;
using System.ComponentModel.DataAnnotations;

namespace MagazinKompTechniki.Entity
{
    public class PaymentForTheOrder
    {
        private static ApplicationContext db = Context.Db;
        public int ID { get; set; }
        [Required] public double OrderCost { get; set; }
        [Required] public virtual Order Order { get; set; }
        public PaymentForTheOrder() { }
        public PaymentForTheOrder(Order order, double orderCost)
        {
            Order = order;
            OrderCost = orderCost;
        }
        public static void Add(PaymentForTheOrder paymentForTheOrder)
        {
            db.PaymentForTheOrder.Add(paymentForTheOrder);
            db.SaveChanges();
        }
    }
}
