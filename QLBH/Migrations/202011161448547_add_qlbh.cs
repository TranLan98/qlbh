namespace QLBH.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add_qlbh : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.categories",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        name = c.String(nullable: false, maxLength: 30),
                        content = c.String(),
                        created_at = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.products",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        name = c.String(nullable: false, maxLength: 50),
                        category_id = c.Int(nullable: false),
                        image = c.String(),
                        unitPrice = c.Int(nullable: false),
                        created_at = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.categories", t => t.category_id, cascadeDelete: true)
                .Index(t => t.category_id);
            
            CreateTable(
                "dbo.orderDetails",
                c => new
                    {
                        product_id = c.Int(nullable: false),
                        order_id = c.Int(nullable: false),
                        price = c.Int(nullable: false),
                        quantity = c.Int(nullable: false),
                        created_at = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.product_id)
                .ForeignKey("dbo.orders", t => t.order_id, cascadeDelete: true)
                .ForeignKey("dbo.products", t => t.product_id)
                .Index(t => t.product_id)
                .Index(t => t.order_id);
            
            CreateTable(
                "dbo.orders",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        user_id = c.Int(nullable: false),
                        status = c.String(),
                        node = c.String(),
                        total = c.Int(nullable: false),
                        created_at = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.users", t => t.user_id, cascadeDelete: true)
                .Index(t => t.user_id);
            
            CreateTable(
                "dbo.users",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        name = c.String(),
                        email = c.String(),
                        password = c.String(),
                        phone = c.String(nullable: false, maxLength: 13),
                        address = c.String(),
                        create_at = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.orderDetails", "product_id", "dbo.products");
            DropForeignKey("dbo.orders", "user_id", "dbo.users");
            DropForeignKey("dbo.orderDetails", "order_id", "dbo.orders");
            DropForeignKey("dbo.products", "category_id", "dbo.categories");
            DropIndex("dbo.orders", new[] { "user_id" });
            DropIndex("dbo.orderDetails", new[] { "order_id" });
            DropIndex("dbo.orderDetails", new[] { "product_id" });
            DropIndex("dbo.products", new[] { "category_id" });
            DropTable("dbo.users");
            DropTable("dbo.orders");
            DropTable("dbo.orderDetails");
            DropTable("dbo.products");
            DropTable("dbo.categories");
        }
    }
}
