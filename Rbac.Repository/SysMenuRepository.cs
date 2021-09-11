using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rbac.Entity;
using Rbac.IRepository;

namespace Rbac.Repository
{
    public class SysMenuRepository : BaseRepository<SysMenu,int>, ISysMenuRepository
    {
        private RbacDbContext _db;

        public SysMenuRepository(RbacDbContext db)
        {
            this.__db = db;
            this._db = db;
        }
    }
}
