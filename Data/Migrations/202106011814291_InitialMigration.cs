namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Brands",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        BrandName = c.String(nullable: false, maxLength: 30),
                        CountryOfOrigin = c.String(nullable: false, maxLength: 50),
                        FoundedIn = c.Short(nullable: false),
                        AddedOn = c.DateTime(),
                        AddedFrom = c.String(nullable: false, maxLength: 50),
                        LowestModelPrice = c.Int(nullable: false),
                        CreatedBy = c.Int(),
                        CreatedOn = c.DateTime(),
                        UpdatedBy = c.Int(),
                        UpdatedOn = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Cars",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        BrandID = c.Int(nullable: false),
                        Model = c.String(nullable: false, maxLength: 80),
                        Condition = c.String(nullable: false, maxLength: 10),
                        Color = c.String(nullable: false, maxLength: 50),
                        Power = c.Int(nullable: false),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ManifactureDate = c.DateTime(nullable: false),
                        Details = c.String(maxLength: 70),
                        AddedBy = c.String(nullable: false, maxLength: 50),
                        CreatedBy = c.Int(),
                        CreatedOn = c.DateTime(),
                        UpdatedBy = c.Int(),
                        UpdatedOn = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Brands", t => t.BrandID, cascadeDelete: true)
                .Index(t => t.BrandID);
            
            CreateTable(
                "dbo.Sales",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CarID = c.Int(nullable: false),
                        ClientFirstName = c.String(nullable: false),
                        ClientLastName = c.String(nullable: false),
                        SellerName = c.String(),
                        SaleDate = c.DateTime(),
                        SalePrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CreatedBy = c.Int(),
                        CreatedOn = c.DateTime(),
                        UpdatedBy = c.Int(),
                        UpdatedOn = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Cars", t => t.CarID, cascadeDelete: true)
                .Index(t => t.CarID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Sales", "CarID", "dbo.Cars");
            DropForeignKey("dbo.Cars", "BrandID", "dbo.Brands");
            DropIndex("dbo.Sales", new[] { "CarID" });
            DropIndex("dbo.Cars", new[] { "BrandID" });
            DropTable("dbo.Sales");
            DropTable("dbo.Cars");
            DropTable("dbo.Brands");
        }
    }
}
