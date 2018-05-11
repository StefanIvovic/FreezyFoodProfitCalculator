namespace FreezyFood_Profit_Calculator.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedProductAndAssociationWithUnit : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ProductName = c.String(nullable: false),
                        PricePerKG = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Units", "Product_Id", c => c.Int());
            CreateIndex("dbo.Units", "Product_Id");
            AddForeignKey("dbo.Units", "Product_Id", "dbo.Products", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Units", "Product_Id", "dbo.Products");
            DropIndex("dbo.Units", new[] { "Product_Id" });
            DropColumn("dbo.Units", "Product_Id");
            DropTable("dbo.Products");
        }
    }
}
