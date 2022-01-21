using MagazinKompTechnikiDLL;
using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace MagazinKompTechniki.Entity
{
    public class Delivery
    {
        private static ApplicationContext db = Context.Db;
        public int ID { get; set; }
        [Required] public DateTime DeliveryDate { get; set; }
        [Required] [MaxLength(50)] public string Street { get; set; }
        [Required] [MaxLength(50)] public string House { get; set; }
        [Required] public int Flat { get; set; }
        [Required] public double DeliveryCost { get; set; }
        [Required] public virtual Employee Employee { get; set; }
        [Required] public virtual Client Client { get; set; }

        public Delivery() { }
        public Delivery(DateTime dateTime, string street, string house, int flat, double deliveryCost, Employee employee, Client client)
        {
            this.DeliveryDate = dateTime;
            this.Street = street;
            this.House = house;
            this.Flat = flat;
            this.DeliveryCost = deliveryCost;
            this.Employee = employee;
            this.Client = client;
        }
        /// <summary>
        /// Получение доставки
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static Delivery GetDeliveryById(int id)
        {
            return (from d in db.Delivery
                    where d.ID == id
                    select d).FirstOrDefault();
        }
        public static string GetDeliveryAdress(Delivery delivery)
        {
            return $"{delivery.Street}, дом №{delivery.House}, квартира {delivery.Flat}";
        }
        /// <summary>
        /// Добавление в базу данных
        /// </summary>
        /// <param name="delivery"></param>
        public static void Add(Delivery delivery)
        {
            db.Delivery.Add(delivery);
            db.SaveChanges();
        }
    }
}
