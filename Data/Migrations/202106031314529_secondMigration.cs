namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class secondMigration : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Sales", "ClientFirstName", c => c.String(nullable: false, maxLength: 20));
            AlterColumn("dbo.Sales", "ClientLastName", c => c.String(nullable: false, maxLength: 20));
            AlterColumn("dbo.Sales", "SellerName", c => c.String(maxLength: 50));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Sales", "SellerName", c => c.String());
            AlterColumn("dbo.Sales", "ClientLastName", c => c.String(nullable: false));
            AlterColumn("dbo.Sales", "ClientFirstName", c => c.String(nullable: false));
        }
    }
}
