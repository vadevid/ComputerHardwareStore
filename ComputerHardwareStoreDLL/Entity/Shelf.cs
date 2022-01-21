using MagazinKompTechnikiDLL;
using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MagazinKompTechniki.Entity
{
    public class Shelf
    {
        private static ApplicationContext db = Context.Db;
        public int ID { get; set; }
        [Required] [MaxLength(50)] public string ProductModel { get; set; }
        [Required] public int Capacity { get; set; }
        [Required] public virtual Rack Rack { get; set; }
        [Required] public virtual List<Product> Products { get; set; }
        public Shelf ()
        {
            Products = new List<Product> ();
        }
        public static int GetShelf(string productModel, string productManufacturer)
        {
            return (from sh in db.Shelf
                    join r in db.Rack on sh.Rack.ID equals r.ID
                    join c in db.Compartment on r.Compartment.ID equals c.ID
                    where sh.ProductModel == productModel && r.Manufacturer == productManufacturer
                    select sh.ID
                    ).FirstOrDefault();
        }
        public static List<string> GetModels(string productManufacturer, string productType)
        {
            return (from sh in db.Shelf
                    join r in db.Rack on sh.Rack.ID equals r.ID
                    join c in db.Compartment on r.Compartment.ID equals c.ID
                    where r.Manufacturer == productManufacturer && c.ProductType == productType
                    select sh.ProductModel
                    ).ToList();
        }
        public static Shelf GetShelfByID(int id)
        {
            return db.Shelf.Where(r => r.ID == id).FirstOrDefault();
        }
    }
}
