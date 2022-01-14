using MagazinKompTechnikiDLL;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace MagazinKompTechniki.Entity
{
    public class Client
    {
        public int ID { get; set; }
        [Required] [MaxLength(50)] public string SecondName { get; set; }
        [Required] [MaxLength(50)] public string FirstName { get; set; }
        [MaxLength(50)] public string MiddleName { get; set; }
        [MaxLength(50)] public string Adress { get; set; }
        public string FullName
        {
            get
            {
                var temp = $"{SecondName} {FirstName.Substring(0,1)}.";
                if (MiddleName != null) temp += $"{MiddleName.Substring(0, 1)}.";
                return temp;
            }
        }
        private static ApplicationContext db = Context.Db;

        public static List<Client> GetAllClients()
        {
            return (from c in db.Client
                    select c).ToList();
        }

        public static Client GetClientByFullname(string secondName, string firstName, string middleName)
        {
            Client client;
            if (middleName!="")
            {
                 client = (from c in db.Client
                                 where c.SecondName == secondName && c.FirstName == firstName && c.MiddleName == middleName
                                 select c).FirstOrDefault();
            } else
            {
                client = (from c in db.Client
                                 where c.SecondName == secondName && c.FirstName == firstName
                                 select c).FirstOrDefault();
            }
            
            return client;
        }

        public static List<ClientInfo> GetClientInfo()
        {
            return (from c in db.Client
                    select new ClientInfo()
                    {
                        ID = c.ID,
                        SecondName = c.SecondName,
                        FirstName = c.FirstName,
                        MiddleName = c.MiddleName,
                        Adress = c.Adress,
                    }).ToList();
        }
        public class ClientInfo
        {
            public int ID { get; set; }
            public string SecondName { get; set; }
            public string FirstName { get; set; }
            public string MiddleName { get; set; }
            public string Adress { get; set; }
        }
        public static void Add(Client client)
        {
            db.Client.Add(client);
            db.SaveChanges();
        }
    }
    
}
