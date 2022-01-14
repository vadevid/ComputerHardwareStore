using MagazinKompTechnikiDLL;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Linq;

namespace MagazinKompTechniki.Entity
{
    public class Product
    {
        public int ID { get; set; }
        [Required] [MaxLength(50)] public string ProductName { get; set; }
        [Required] public double ProductCost { get; set; }
        [Required] [MaxLength(22)] public string SerialNumber { get; set; }
        [Required] public Shelf Shelf { get; set; }
        [Required] public List<Order> Orders { get; set; }
        [Required] public List<Supply> Supplys { get; set; }
        [Required] public int Count {get; set;}
        public Product () 
        { 
            Orders = new List<Order> (); 
            Supplys = new List<Supply> ();
        }

        private static ApplicationContext db = Context.Db;

        public static List<Product> GetAllProducts()
        {
            return (from p in db.Product
                    select p).Distinct().ToList();
        }

        public static Product GetProductByName(string name)
        {
            Product product = (from p in db.Product
                               where p.ProductName == name
                               select p).FirstOrDefault();
            return product;
        }
        public static List<ProductInfo> GetProductInfo()
        {
            return (from p in db.Product
                    join sh in db.Shelf on p.Shelf.ID equals sh.ID
                    join r in db.Rack on sh.Rack.ID equals r.ID
                    join c in db.Compartment on r.Compartment.ID equals c.ID

                    select new ProductInfo()
                    {
                        ID = p.ID,
                        ProductName = p.ProductName,
                        ProductType = c.ProductType,
                        ProductCost = p.ProductCost,
                        SerialNumber = p.SerialNumber,
                        ShelfID = sh.ID,
                        Count = p.Count,
                    }).ToList();
        }

        public class ProductInfo
        {
            public int ID { get; set; }
            public string ProductName { get; set; }
            public string ProductType { get; set; }
            public double ProductCost { get; set; }
            public string SerialNumber { get; set; }
            public int ShelfID { get; set; }
            public int Count { get; set; }
        }
        public static void Add(Product product)
        {
            db.Product.Add(product);
            db.SaveChanges();
        }
        public static void UpdateCount(Product product)
        {
            product.Count++;
            db.SaveChanges();
        }
    }
    
}
