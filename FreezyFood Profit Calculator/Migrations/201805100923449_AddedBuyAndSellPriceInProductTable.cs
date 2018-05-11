namespace FreezyFood_Profit_Calculator.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedBuyAndSellPriceInProductTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Products", "PricePerKGBuy", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Products", "PricePerKGSell", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            DropColumn("dbo.Products", "PricePerKG");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Products", "PricePerKG", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            DropColumn("dbo.Products", "PricePerKGSell");
            DropColumn("dbo.Products", "PricePerKGBuy");
        }
    }
}
