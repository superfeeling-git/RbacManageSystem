using Rbac.Entity;
using Rbac.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Rbac.Dtos.Role;

namespace Rbac.Repository
{
    public class RoleRepository : BaseRepository<Role, int>, IRoleRepository
    {
        private RbacDbContext _db;

        public RoleRepository(RbacDbContext db)
        {
            this.__db = db;
            this._db = db;
        }

        public async Task<List<int>> GetPermission(int id)
        {
            var list = await _db.RoleMenu.Where(m => m.RoleId == id).ToListAsync();
            return list.Select(m => m.MenuId).ToList();
        }

        public async Task SetPermission(Permission permission)
        {
            await _db.RoleMenu.Where(m=>m.RoleId == permission.RoleId).DeleteFromQueryAsync();
            List<RoleMenu> roles = new List<RoleMenu>();
            foreach (var item in permission.MenuId)
            {
                roles.Add(new RoleMenu { RoleId = permission.RoleId, MenuId = item });
            }
            await _db.RoleMenu.AddRangeAsync(roles);
            await _db.SaveChangesAsync();
        }
    }
}
