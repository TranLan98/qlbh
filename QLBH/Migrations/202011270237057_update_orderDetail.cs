namespace QLBH.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update_orderDetail : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.orderDetails", "product_id", "dbo.products");
            DropPrimaryKey("dbo.orderDetails");
            AddColumn("dbo.orderDetails", "id", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.orderDetails", "id");
            AddForeignKey("dbo.orderDetails", "product_id", "dbo.products", "id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.orderDetails", "product_id", "dbo.products");
            DropPrimaryKey("dbo.orderDetails");
            DropColumn("dbo.orderDetails", "id");
            AddPrimaryKey("dbo.orderDetails", "product_id");
            AddForeignKey("dbo.orderDetails", "product_id", "dbo.products", "id");
        }
    }
}
