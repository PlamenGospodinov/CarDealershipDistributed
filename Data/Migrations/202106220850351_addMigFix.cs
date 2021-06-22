namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addMigFix : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Brands", "AddedOn", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Sales", "SaleDate", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Sales", "SaleDate", c => c.DateTime());
            AlterColumn("dbo.Brands", "AddedOn", c => c.DateTime());
        }
    }
}
