namespace FreezyFood_Profit_Calculator.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedProfitPercINProduct : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Products", "ProfitPercentage", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Products", "ProfitPercentage");
        }
    }
}
