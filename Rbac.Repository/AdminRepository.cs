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
        private RbacDbContext _db;

        public AdminRepository(RbacDbContext db)
        {
            this.__db = db;
            this._db = db;
        }

        public override async Task<Admin> FindAsync(int key)
        {            
            var admin = await base.FindAsync(key);
            admin.AdminRole = await _db.AdminRole.Where(m => m.AdminId == key).ToListAsync();
            return admin;
        }

        public async Task<int> RemoveRole(int adminId)
        {
            return await _db.AdminRole.Where(m => m.AdminId == adminId).DeleteFromQueryAsync();
        }

        public async Task BulkInsertAsync(IEnumerable<AdminRole> entitys)
        {
            await _db.AdminRole.AddRangeAsync(entitys);
            await _db.SaveChangesAsync();
        }
    }
}