using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Rbac.Entity
{
    public class RbacDbContext : DbContext
    {
        public RbacDbContext(DbContextOptions<RbacDbContext> options):
            base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Admin>(action => {
                action.HasKey(m => m.AdminId);
                action.Property<string>("LastModify").HasColumnType("nvarchar(500)");
            });

            modelBuilder.Entity<AdminRole>(action => {
                action.HasKey(m => m.Id);
            });

            modelBuilder.Entity<Role>(action => {
                action.HasKey(m => m.RoleID);
            });

            modelBuilder.Entity<RoleMenu>(action => {
                action.HasKey(m => m.Id);
                action.HasOne(m => m.SysMenu).WithMany(m => m.RoleMenu).HasForeignKey(m => m.MenuId);                
            });

            modelBuilder.Entity<SysMenu>(action => {
                action.HasKey(m => m.MenuID);
            });

            modelBuilder.Entity<Goods>(action => {
                action.HasKey(m => m.GoodsID);
                action.Property(m => m.GoodsName).HasMaxLength(50).IsRequired(true);
                action.Property(m => m.GoodsPic).HasMaxLength(500).IsRequired(true);
            });

            base.OnModelCreating(modelBuilder);
        }

        public virtual DbSet<Admin> Admin { get; set; }
        public virtual DbSet<AdminRole> AdminRole { get; set; }
        public virtual DbSet<Role> Role { get; set; }
        public virtual DbSet<RoleMenu> RoleMenu { get; set; }
        public virtual DbSet<SysMenu> SysMenu { get; set; }
    }
}
