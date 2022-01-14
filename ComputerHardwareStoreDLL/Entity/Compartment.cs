using MagazinKompTechnikiDLL;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Linq;

namespace MagazinKompTechniki.Entity
{
    public class Compartment
    {
        public int ID { get; set; }
        [Required] [MaxLength(50)] public string ProductType { get; set; }
        [Required] public int Capacity { get; set; }
        [Required] public Warehouse Warehouse { get; set; }
        [Required] public List<Rack> Racks { get; set; }
        public Compartment ()
        {
            Racks = new List<Rack> ();
        }

        private static ApplicationContext db = Context.Db;

        public static List<string> GetProductTypes ()
        {
            return (from c in db.Compartment
                    select c.ProductType).ToList();
        }
    }
}
