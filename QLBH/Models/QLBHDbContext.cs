namespace QLBH.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class QLBHDbContext : DbContext
    {
        public virtual DbSet<category> categories { get; set; }
        public virtual DbSet<product> products { get; set; }
        public virtual DbSet<orderDetail> orderDetails { get; set; }
        public virtual DbSet<order> orders { get; set; }
        public virtual DbSet<user> users { get; set; }
        public QLBHDbContext()
            : base("name=QLBHDbContext")
        {
        }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }

        //public System.Data.Entity.DbSet<QLBH.Models.category> categories { get; set; }
    }
}
