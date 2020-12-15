namespace QLBH.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add_role_user : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.users", "role", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.users", "role");
        }
    }
}
