namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removeBaseThings : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Brands", "CreatedBy");
            DropColumn("dbo.Brands", "CreatedOn");
            DropColumn("dbo.Brands", "UpdatedBy");
            DropColumn("dbo.Brands", "UpdatedOn");
            DropColumn("dbo.Cars", "CreatedBy");
            DropColumn("dbo.Cars", "CreatedOn");
            DropColumn("dbo.Cars", "UpdatedBy");
            DropColumn("dbo.Cars", "UpdatedOn");
            DropColumn("dbo.Sales", "CreatedBy");
            DropColumn("dbo.Sales", "CreatedOn");
            DropColumn("dbo.Sales", "UpdatedBy");
            DropColumn("dbo.Sales", "UpdatedOn");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Sales", "UpdatedOn", c => c.DateTime());
            AddColumn("dbo.Sales", "UpdatedBy", c => c.Int());
            AddColumn("dbo.Sales", "CreatedOn", c => c.DateTime());
            AddColumn("dbo.Sales", "CreatedBy", c => c.Int());
            AddColumn("dbo.Cars", "UpdatedOn", c => c.DateTime());
            AddColumn("dbo.Cars", "UpdatedBy", c => c.Int());
            AddColumn("dbo.Cars", "CreatedOn", c => c.DateTime());
            AddColumn("dbo.Cars", "CreatedBy", c => c.Int());
            AddColumn("dbo.Brands", "UpdatedOn", c => c.DateTime());
            AddColumn("dbo.Brands", "UpdatedBy", c => c.Int());
            AddColumn("dbo.Brands", "CreatedOn", c => c.DateTime());
            AddColumn("dbo.Brands", "CreatedBy", c => c.Int());
        }
    }
}
