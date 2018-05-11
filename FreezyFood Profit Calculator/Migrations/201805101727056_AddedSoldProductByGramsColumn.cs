namespace FreezyFood_Profit_Calculator.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedSoldProductByGramsColumn : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Units", "SaleInGrams", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            DropColumn("dbo.Units", "Price");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Units", "Price", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            DropColumn("dbo.Units", "SaleInGrams");
        }
    }
}
