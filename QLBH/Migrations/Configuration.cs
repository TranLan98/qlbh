namespace QLBH.Migrations
{
    using QLBH.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<QLBH.Models.QLBHDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(QLBH.Models.QLBHDbContext context)
        {
            //tạo sãn database
            context.users.AddOrUpdate(k => k.name,
                new user
                {
                    name = "A",
                    address = "Đà Nẵng"


                },
                new user
                {
                    name = "B",
                    address = "Hà Nội"
                }

                );
        }
    }
}
