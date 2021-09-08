using Rbac.Entity;
using Rbac.IRepositoty;
using System;
using System.Collections.Generic;
using System.Linq;
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
    }
}
