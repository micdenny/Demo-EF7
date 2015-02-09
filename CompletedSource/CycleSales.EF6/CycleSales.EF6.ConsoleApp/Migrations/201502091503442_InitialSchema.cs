using System.Data.Entity.Migrations;

namespace CycleSales.EF6.ConsoleApp.Migrations
{
    public partial class InitialSchema : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Bikes",
                c => new
                    {
                        Bike_Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        ModelNo = c.String(),
                        Retail = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Description = c.String(),
                        ImageUrl = c.String(),
                    })
                .PrimaryKey(t => t.Bike_Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Bikes");
        }
    }
}
