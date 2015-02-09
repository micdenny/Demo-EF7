using System.Data.Entity.Migrations;
using CycleSales.EF6.ConsoleApp.CycleSalesModel;

namespace CycleSales.EF6.ConsoleApp.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<CycleSalesContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(CycleSalesContext db)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

            db.Bikes.AddOrUpdate(
                t => t.Bike_Id,
                new Bike
                {
                    Bike_Id = 1,
                    Name = "Mountain Monster 7000",
                    ModelNo = "MM7000",
                    Retail = 349.95M,
                    Description = "Tackle the mountains with confidence and attitude. Built to go fast, built to go hard, and built to last.",
                    ImageUrl = "~/ImageUploads/MountainMonster7000.png"
                },
                new Bike
                {
                    Bike_Id = 2,
                    Name = "BMX Bandit B500",
                    ModelNo = "BBB500",
                    Retail = 249.95M,
                    Description = "Get your skills on with this little monster. Fly high, fly fast, and fly in style.",
                    ImageUrl = "~/ImageUploads/BmxBanditB500.png"
                },
                new Bike
                {
                    Bike_Id = 3,
                    Name = "Toddler Terror Trainer 200",
                    ModelNo = "TTT200",
                    Retail = 199.95M,
                    Description = "The premium menacing machine for your young and aspiring bike rider. Who said training wheels couldn't look cool.",
                    ImageUrl = "~/ImageUploads/ToddlerTerrorTrainer200.png"
                });

            db.SaveChanges();
        }
    }
}