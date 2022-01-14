using MagazinKompTechnikiDLL;
using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MagazinKompTechniki.Entity
{
    public class Rack
    {
        public int ID { get; set; }
        [Required] [MaxLength(50)] public string Manufacturer { get; set; }
        [Required] public int Capacity { get; set; }
        [Required] public List<Shelf> Shelfs { get; set; }
        [Required] public Compartment Compartment { get; set; }
        public Rack ()
        {
            Shelfs = new List<Shelf> ();
        }
        private static ApplicationContext db = Context.Db;
        public static List<string> GetManufacturers(string productType)
        {
            return (from r in db.Rack
                    join c in db.Compartment on r.Compartment.ID  equals c.ID
                    where c.ProductType == productType
                    select r.Manufacturer
                    ).ToList();
        }

    }
}
