namespace QLBH.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update_table_user : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.users", "email", c => c.String(nullable: false));
            AlterColumn("dbo.users", "password", c => c.String(nullable: false));
            DropColumn("dbo.users", "create_at");
        }
        
        public override void Down()
        {
            AddColumn("dbo.users", "create_at", c => c.DateTime(nullable: false));
            AlterColumn("dbo.users", "password", c => c.String());
            AlterColumn("dbo.users", "email", c => c.String());
        }
    }
}
