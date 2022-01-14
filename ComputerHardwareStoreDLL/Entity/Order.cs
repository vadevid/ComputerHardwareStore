using MagazinKompTechnikiDLL;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Linq;

namespace MagazinKompTechniki.Entity
{
    public class Order
    {
        public int ID { get; set; }
        [Required] public DateTime OrderDate { get; set; }
        [Required] public Employee Employee { get; set; }
        [Required] public Client Client { get; set; }
        [Required] public List<Product> Products { get; set; }  
        public Delivery Delivery { get; set; }
        public string Status { get; set; }
        public Order() 
        { 
            Products = new List<Product>(); 
        }
        private static ApplicationContext db = Context.Db;


        public static List<OrderInfo> GetOrderInfo()
        {
            return (from o in db.Order
                    join c in db.Client on o.Client.ID equals c.ID
                    join e in db.Employee on o.Employee.ID equals e.ID
                    select new OrderInfo()
                    {
                        ID = o.ID,
                        FIOClienta = c.FullName,
                        FIOEmployee = e.FullName,
                        OrderDate = o.OrderDate,
                        Status = o.Status,
                    }).ToList();
        }
        public class OrderInfo
        {
            public int ID { get; set; }
            public string FIOClienta { get; set; }
            public string FIOEmployee { get; set; }
            public DateTime OrderDate { get; set; }
            public string Status { get; set; }
        }
        public static void Add(Order order)
        {
            db.Order.Add(order);
            db.SaveChanges();
        }
    }
}
