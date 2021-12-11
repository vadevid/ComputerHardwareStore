using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using MagazinKompTechniki.Entity;

namespace MagazinKompTechniki
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext()
        {
            Database.EnsureCreated();
        }
        public ApplicationContext(DbContextOptions<ApplicationContext> options) :base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql($"Host=localhost;Port=5432;Database=magazin_1;Username=vadevid;Password=dfg234hj");
        }

        public DbSet<Client> Client { get; set; }
        public DbSet<Compartment> Compartment { get; set; }
        public DbSet<SuppliedProduct> DeliveredProduct { get; set; }
        public DbSet<Delivery> Delivery { get; set; }
        public DbSet<Employee> Employee { get; set; }
        public DbSet<Guarantee> Guarantee { get; set; }
        public DbSet<Manufacturer> Manufacturer { get; set; }
        public DbSet<Order> Order { get; set; }
        public DbSet<OrderedProduct> OrderedProduct { get; set; }
        public DbSet<PaymentForSupply> PaymentForDelivery { get; set; }
        public DbSet<PaymentForTheOrder> PaymentForTheOrder { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<Rack> Rack { get; set; }
        public DbSet<Shelf> Shelf { get; set; }
        public DbSet<Supply> Supply { get; set; }
        public DbSet<Warehouse> Warehouse { get; set; }
    }  
}
