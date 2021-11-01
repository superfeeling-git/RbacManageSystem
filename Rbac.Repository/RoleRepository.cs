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

        public async Task SetPermission(RoleMenuDto roleMenuDto)
        {
            await _db.RoleMenu.Where(m=>m.RoleId == roleMenuDto.RoleId).DeleteFromQueryAsync();
            List<RoleMenu> roles = new List<RoleMenu>();
            foreach (var item in roleMenuDto.MenuId)
            {
                roles.Add(new RoleMenu { RoleId = roleMenuDto.RoleId, MenuId = item });
            }
            await _db.RoleMenu.AddRangeAsync(roles);
            await _db.SaveChangesAsync();
        }

        public List<int> getRolesByMenu(string url)
        {
            return _db.RoleMenu
                .Where(m => _db.SysMenu.Where(m => m.MenuLink == url.ToLower()).Select(m => m.MenuId).Contains(m.MenuId))
                .Select(a => a.RoleId).ToList();

            /*return await _db.Role.Join(_db.RoleMenu, a => a.RoleId, b => b.RoleId, (a, b) => new { a, b })
                .Join(_db.SysMenu, a => a.b.MenuId, b => b.MenuId, (a, b) => new { a, b })
                .Where(m => m.b.MenuLink == url.ToLower())
                .Select(m => m.a.b.RoleId).ToListAsync();*/
        }

        public Task SetPermission(Permission permission)
        {
            throw new NotImplementedException();
        }
    }
}
