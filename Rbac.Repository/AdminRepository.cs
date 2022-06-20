using Microsoft.EntityFrameworkCore;
using Rbac.Entity;
using Rbac.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Rbac.Repository
{
    public class AdminRepository : BaseRepository<Admin, int>, IAdminRepository
    {
        //private RbacDbContext _db;

        public AdminRepository(RbacDbContext db)
        {
            this.__db = db;
        }

        public override async Task<Admin> FindAsync(int key)
        {            
            var admin = await base.FindAsync(key);
            admin.AdminRole = await __db.AdminRole.Where(m => m.AdminId == key).ToListAsync();
            return admin;
        }

        public async Task<List<int>> GetRoleAsync(int adminId)
        {
            return await __db.AdminRole.Where(m => m.AdminId == adminId).Select(m=>m.RoleId).ToListAsync();
        }

        public async Task<int> RemoveRoleAsync(int adminId)
        {
            return await __db.AdminRole.Where(m => m.AdminId == adminId).DeleteFromQueryAsync();
        }

        public async Task BulkInsertAsync(IEnumerable<AdminRole> entitys)
        {
            await __db.AdminRole.AddRangeAsync(entitys);
            await __db.SaveChangesAsync();
        }

        public override Task<int> CreateAsync(Admin entity)
        {
            return base.CreateAsync(entity);
        }
    }
}