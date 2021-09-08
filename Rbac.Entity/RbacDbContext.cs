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

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Admin> Admin { get; set; }
        public DbSet<AdminRole> AdminRole { get; set; }
        public DbSet<Role> Role { get; set; }
        public DbSet<RoleMenu> RoleMenu { get; set; }
        public DbSet<SysMenu> SysMenu { get; set; }
    }
}
