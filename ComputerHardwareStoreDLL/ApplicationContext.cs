using MagazinKompTechniki.Entity;
using MagazinKompTechnikiDLL;
using Microsoft.EntityFrameworkCore;

namespace MagazinKompTechniki
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
            Database.Migrate();
            Context.AddDb(this);
        }
        public static DbContextOptions<ApplicationContext> GetDB()
        {
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationContext>();
            return optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=magazin_1;Username=vadevid;Password=dfg234hj").UseLazyLoadingProxies().Options;
        }
        public DbSet<Client> Client { get; set; }
        public DbSet<Compartment> Compartment { get; set; }
        public DbSet<Delivery> Delivery { get; set; }
        public DbSet<Employee> Employee { get; set; }
        public DbSet<Guarantee> Guarantee { get; set; }
        public DbSet<Manufacturer> Manufacturer { get; set; }
        public DbSet<Order> Order { get; set; }
        public DbSet<PaymentForSupply> PaymentForDelivery { get; set; }
        public DbSet<PaymentForTheOrder> PaymentForTheOrder { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<Rack> Rack { get; set; }
        public DbSet<Shelf> Shelf { get; set; }
        public DbSet<Supply> Supply { get; set; }
        public DbSet<Warehouse> Warehouse { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>()
                .HasMany(c => c.Orders)
                .WithMany(s => s.Products)
                .UsingEntity(j => j.ToTable("OrderedProducts"));            
            modelBuilder.Entity<Product>()
                .Property(p => p.Count).HasDefaultValue(1);
        }
    }
}
