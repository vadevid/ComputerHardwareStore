using MagazinKompTechnikiDLL;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace MagazinKompTechniki.Entity
{
    public class Order
    {
        private static ApplicationContext db = Context.Db;
        public int ID { get; set; }
        [Required] public DateTime OrderDate { get; set; }
        [Required] public virtual Employee Employee { get; set; }
        [Required] public virtual Client Client { get; set; }
        [Required] public virtual List<Product> Products { get; set; }
        public virtual Guarantee Guarantee { get; set; }
        public virtual Delivery Delivery { get; set; }
        public string Status { get; set; }
        public class OrderInfo
        {
            public int ID { get; set; }
            public string FIOClienta { get; set; }
            public string FIOEmployee { get; set; }
            public DateTime OrderDate { get; set; }
            public string Status { get; set; }
        }
        public Order()
        {
            Products = new List<Product>();
        }
        /// <summary>
        /// Получение продуктов из заказа
        /// </summary>
        public static List<Product> GetOrderedProducts(int orderId)
        {
            return
                (from o in db.Order
                 where o.ID == orderId
                 select o.Products).FirstOrDefault();

        }
        /// <summary>
        /// Получение продуктов тем или иным образом
        /// </summary>
        public static Order GetOrderById(int id)
        {
            return (from o in db.Order
                    where o.ID == id
                    select o).FirstOrDefault();
        }
        public static List<Order> GetAllOrder()
        {
            return (from o in db.Order select o).ToList();
        }        
        public static OrderInfo GetOrderInfoById(int id)
        {
            return (from o in db.Order
                    join c in db.Client on o.Client.ID equals c.ID
                    join e in db.Employee on o.Employee.ID equals e.ID
                    where o.ID == id
                    select new OrderInfo()
                    {
                        ID = o.ID,
                        FIOClienta = c.GetFullName(),
                        FIOEmployee = e.GetFullName(),
                        OrderDate = o.OrderDate,
                        Status = o.Status,
                    }).FirstOrDefault();
        }
        /// <summary>
        /// Получение информации о заказах
        /// </summary>
        public static List<OrderInfo> GetOrderInfo()
        {
            return (from o in db.Order
                    join c in db.Client on o.Client.ID equals c.ID
                    join e in db.Employee on o.Employee.ID equals e.ID
                    select new OrderInfo()
                    {
                        ID = o.ID,
                        FIOClienta = c.GetFullName(),
                        FIOEmployee = e.GetFullName(),
                        OrderDate = o.OrderDate,
                        Status = o.Status,
                    }).ToList();
        }
        /// <summary>
        /// Добавление в базу данных
        /// </summary>
        public static void Add(Order order)
        {
            db.Order.Add(order);
            db.SaveChanges();
        }
        /// <summary>
        /// Изменение заказа
        /// </summary>
        public static void Change(Order order, string status)
        {
            order.Status = status;
            db.SaveChanges();
        }
    }
}
