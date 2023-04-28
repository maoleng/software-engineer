using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Webform.Models
{
    public class SoftwareEntities : DbContext
    {
        public SoftwareEntities(DbContextOptions<SoftwareEntities> options) : base(options)
        {
            //..
            // this.Roles
            // IdentityRole<string>
        }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            base.OnConfiguring(builder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ImportProduct>().HasKey(ip => new { ip.import_id, ip.product_id });
            modelBuilder.Entity<OrderProduct>().HasKey(op => new { op.order_id, op.product_id });

        }

        public virtual DbSet<Admin> Admin { get; set; }
        public virtual DbSet<Discount> Discount { get; set; }
        public virtual DbSet<Import> Import { get; set; }
        public virtual DbSet<ImportProduct> ImportProduct { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<OrderProduct> OrderProduct { get; set; }
        public virtual DbSet<Product> Product { get; set; }
        public virtual DbSet<User> User { get; set; }

    }
}