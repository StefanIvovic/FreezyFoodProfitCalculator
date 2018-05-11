namespace FreezyFood_Profit_Calculator.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class asdf : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Units", "CalculatedProfit", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Units", "CalculatedProfit");
        }
    }
}
