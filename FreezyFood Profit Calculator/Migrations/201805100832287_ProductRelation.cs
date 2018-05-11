namespace FreezyFood_Profit_Calculator.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ProductRelation : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Units", "Product_Id", "dbo.Products");
            DropIndex("dbo.Units", new[] { "Product_Id" });
            RenameColumn(table: "dbo.Units", name: "Product_Id", newName: "ProductId");
            AlterColumn("dbo.Units", "ProductId", c => c.Int(nullable: false));
            CreateIndex("dbo.Units", "ProductId");
            AddForeignKey("dbo.Units", "ProductId", "dbo.Products", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Units", "ProductId", "dbo.Products");
            DropIndex("dbo.Units", new[] { "ProductId" });
            AlterColumn("dbo.Units", "ProductId", c => c.Int());
            RenameColumn(table: "dbo.Units", name: "ProductId", newName: "Product_Id");
            CreateIndex("dbo.Units", "Product_Id");
            AddForeignKey("dbo.Units", "Product_Id", "dbo.Products", "Id");
        }
    }
}
