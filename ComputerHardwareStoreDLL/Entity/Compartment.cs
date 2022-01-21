using MagazinKompTechnikiDLL;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace MagazinKompTechniki.Entity
{
    public class Compartment
    {
        private static ApplicationContext db = Context.Db;
        public int ID { get; set; }
        [Required] [MaxLength(50)] public string ProductType { get; set; }
        [Required] public int Capacity { get; set; }
        [Required] public virtual Warehouse Warehouse { get; set; }
        [Required] public virtual List<Rack> Racks { get; set; }
        public Compartment()
        {
            Racks = new List<Rack>();
        }
        public static List<string> GetProductTypes()
        {
            return (from c in db.Compartment
                    select c.ProductType).ToList();
        }
    }
}
