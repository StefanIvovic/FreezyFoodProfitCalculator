namespace FreezyFood_Profit_Calculator.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removedPercentage : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Units", "ProfitPercentage");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Units", "ProfitPercentage", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
    }
}
