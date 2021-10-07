using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rbac.Entity
{
    public static class ModuleEntity
    {
        public static void build(this ModelBuilder modelBuilder)
        {
            
            modelBuilder.Entity<Admin>(action => {
                action.HasKey(m => m.AdminId);
                action.Property<string>("LastModify").HasColumnType("nvarchar(500)");
            });

            modelBuilder.Entity<AdminRole>(action => {
                action.HasKey(m => m.Id);
            });

            modelBuilder.Entity<Role>(action => {
                action.HasKey(m => m.RoleId);
            });

            modelBuilder.Entity<RoleMenu>(action => {
                action.HasKey(m => m.Id);
                action.HasOne(m => m.SysMenu).WithMany(m => m.RoleMenu).HasForeignKey(m => m.MenuId);
            });

            modelBuilder.Entity<SysMenu>(action => {
                action.HasKey(m => m.MenuId);
            });

            modelBuilder.Entity<Goods>(action => {
                action.HasKey(m => m.GoodsID);
                action.Property(m => m.GoodsName).HasMaxLength(50).IsRequired(true);
                action.Property(m => m.GoodsPic).HasMaxLength(500).IsRequired(true);
                action.HasOne(m => m.GoodsCategory).WithMany(m => m.Goods).HasForeignKey(m => m.CategoryId);
            });

            modelBuilder.Entity<Customer>(action => {
                action.HasKey(m => m.CustomerId);
            });

            modelBuilder.Entity<GoodsCategory>(action => {
                action.HasKey(m => m.CategoryId);
            });
        
            modelBuilder.Entity<Contract>(action => {
                action.HasKey(m => m.ContractId);
            });
        
            modelBuilder.Entity<Department>(action => {
                action.HasKey(m => m.DeptId);
            });
        
            modelBuilder.Entity<GoodsCategory>(action => {
                action.HasKey(m => m.CategoryId);
            });
        
            modelBuilder.Entity<Student>(action => {
                action.HasKey(m => m.StudentId);
            });
        }
    }
}
