using System.Data.Entity;

namespace CycleSales.EF6.ConsoleApp.CycleSalesModel
{
    public class CycleSalesContext : DbContext
    {
        static CycleSalesContext()
        {
            Database.SetInitializer<CycleSalesContext>(null);
        }

        public CycleSalesContext()
            : base(@"Server=(localdb)\v11.0;Database=CycleSales_EF6;integrated security=True;")
        {
        }

        public DbSet<Bike> Bikes { get; set; }

        protected override void OnModelCreating(DbModelBuilder builder)
        {
            builder.Entity<Bike>()
                   .HasKey(b => b.Bike_Id);

            builder.Entity<Bike>()
                   .ToTable("Bikes");
        }
    }
}