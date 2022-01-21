using ComputerHardwareStoreDLL.Entity;
using MagazinKompTechnikiDLL;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace MagazinKompTechniki.Entity
{
    public class Client : Human
    {
        private static ApplicationContext db = Context.Db;
        public int ID { get; set; }        
        [MaxLength(50)] public string Street { get; set; }
        [MaxLength(50)] public string House { get; set; }
        public int Flat { get; set; }
        /// <summary>
        /// Получение полного имени
        /// </summary>
        public override string GetFullName()
        {
            var temp = $"{SecondName} {FirstName} ";
            if (MiddleName != null) temp += $"{MiddleName}";
            return temp;
        }
        public class ClientInfo
        {
            public int ID { get; set; }
            public string SecondName { get; set; }
            public string FirstName { get; set; }
            public string MiddleName { get; set; }
            public string Adress { get; set; }
        }
        /// <summary>
        /// Получение адреса
        /// </summary>
        public string GetFullAdress()
        {
            var temp = $"{this.Street}, {this.House}, {this.Flat}";
            return temp;
        }
        /// <summary>
        /// Получение клиентов в том или ином виде
        /// </summary>
        public static List<Client> GetAllClients()
        {
            return (from c in db.Client
                    select c).ToList();
        }
        public static Client GetClientById(int id)
        {
            return (from c in db.Client
                    where c.ID == id
                    select c).FirstOrDefault();
        }
        public static Client GetClientByFullname(string secondName, string firstName, string middleName)
        {
            Client client;
            if (middleName != "")
            {
                client = (from c in db.Client
                          where c.SecondName == secondName && c.FirstName == firstName && c.MiddleName == middleName
                          select c).FirstOrDefault();
            }
            else
            {
                client = (from c in db.Client
                          where c.SecondName == secondName && c.FirstName == firstName
                          select c).FirstOrDefault();
            }
            return client;
        }
        /// <summary>
        /// Получение информации о клиентах
        /// </summary>
        public static List<ClientInfo> GetClientInfo()
        {
            return (from c in db.Client
                    select new ClientInfo()
                    {
                        ID = c.ID,
                        SecondName = c.SecondName,
                        FirstName = c.FirstName,
                        MiddleName = c.MiddleName,
                        Adress = c.GetFullAdress(),
                    }).ToList();
        }
        /// <summary>
        /// Добавление клиентов в базу данных
        /// </summary>
        public static void Add(Client client)
        {
            db.Client.Add(client);
            db.SaveChanges();
        }
    }

}
